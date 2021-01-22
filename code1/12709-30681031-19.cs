    // A simple decompiler that extracts all method tokens (that is: call, callvirt, newobj in IL)
    internal class Decompiler
    {
        private Decompiler() { }
        static Decompiler()
        {
            singleByteOpcodes = new OpCode[0x100];
            multiByteOpcodes = new OpCode[0x100];
            FieldInfo[] infoArray1 = typeof(OpCodes).GetFields();
            for (int num1 = 0; num1 < infoArray1.Length; num1++)
            {
                FieldInfo info1 = infoArray1[num1];
                if (info1.FieldType == typeof(OpCode))
                {
                    OpCode code1 = (OpCode)info1.GetValue(null);
                    ushort num2 = (ushort)code1.Value;
                    if (num2 < 0x100)
                    {
                        singleByteOpcodes[(int)num2] = code1;
                    }
                    else
                    {
                        if ((num2 & 0xff00) != 0xfe00)
                        {
                            throw new Exception("Invalid opcode: " + num2.ToString());
                        }
                        multiByteOpcodes[num2 & 0xff] = code1;
                    }
                }
            }
        }
        private static OpCode[] singleByteOpcodes;
        private static OpCode[] multiByteOpcodes;
        public static MethodBase[] Decompile(MethodBase mi, byte[] ildata)
        {
            HashSet<MethodBase> result = new HashSet<MethodBase>();
            Module module = mi.Module;
            int position = 0;
            while (position < ildata.Length)
            {
                OpCode code = OpCodes.Nop;
                ushort b = ildata[position++];
                if (b != 0xfe)
                {
                    code = singleByteOpcodes[b];
                }
                else
                {
                    b = ildata[position++];
                    code = multiByteOpcodes[b];
                    b |= (ushort)(0xfe00);
                }
                switch (code.OperandType)
                {
                    case OperandType.InlineNone:
                        break;
                    case OperandType.ShortInlineBrTarget:
                    case OperandType.ShortInlineI:
                    case OperandType.ShortInlineVar:
                        position += 1;
                        break;
                    case OperandType.InlineVar:
                        position += 2;
                        break;
                    case OperandType.InlineBrTarget:
                    case OperandType.InlineField:
                    case OperandType.InlineI:
                    case OperandType.InlineSig:
                    case OperandType.InlineString:
                    case OperandType.InlineTok:
                    case OperandType.InlineType:
                    case OperandType.ShortInlineR:
                        position += 4;
                        break;
                    case OperandType.InlineR:
                    case OperandType.InlineI8:
                        position += 8;
                        break;
                    case OperandType.InlineSwitch:
                        int count = BitConverter.ToInt32(ildata, position);
                        position += count * 4 + 4;
                        break;
                    case OperandType.InlineMethod:
                        int methodId = BitConverter.ToInt32(ildata, position);
                        position += 4;
                        try
                        {
                            if (mi is ConstructorInfo)
                            {
                                result.Add((MethodBase)module.ResolveMember(methodId, mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes));
                            }
                            else
                            {
                                result.Add((MethodBase)module.ResolveMember(methodId, mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments()));
                            }
                        }
                        catch { } 
                        break;
                    
                    default:
                        throw new Exception("Unknown instruction operand; cannot continue. Operand type: " + code.OperandType);
                }
            }
            return result.ToArray();
        }
    }
    class StackOverflowDetector
    {
        // This method will be found:
        static int Recur()
        {
            CheckStackDepth();
            int variable = 1;
            return variable + Recur();
        }
        static void Main(string[] args)
        {
            RecursionDetector();
            Console.WriteLine();
            Console.ReadLine();
        }
        static void RecursionDetector()
        {
            // First decompile all methods in the assembly:
            Dictionary<MethodBase, MethodBase[]> calling = new Dictionary<MethodBase, MethodBase[]>();
            var assembly = typeof(StackOverflowDetector).Assembly;
            foreach (var type in assembly.GetTypes())
            {
                foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).OfType<MethodBase>())
                {
                    var body = member.GetMethodBody();
                    if (body!=null)
                    {
                        var bytes = body.GetILAsByteArray();
                        if (bytes != null)
                        {
                            // Store all the calls of this method:
                            var calls = Decompiler.Decompile(member, bytes);
                            calling[member] = calls;
                        }
                    }
                }
            }
            // Check every method:
            foreach (var method in calling.Keys)
            {
                // If method A -> ... -> method A, we have a possible infinite recursion
                CheckRecursion(method, calling, new HashSet<MethodBase>());
            }
        }
