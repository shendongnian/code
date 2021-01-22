    [AttributeUsage(AttributeTargets.GenericParameter)]
    public class IsInterface : ConstraintAttribute
    {
        public override bool Check(Type genericType)
        {
            return genericType.IsInterface;
        }
        public override string ToString()
        {
            return "Generic type is not an interface";
        }
    }
    public abstract class ConstraintAttribute : Attribute
    {
        public ConstraintAttribute() {}
        public abstract bool Check(Type generic);
    }
    internal class BigEndianByteReader
    {
        public BigEndianByteReader(byte[] data)
        {
            this.data = data;
            this.position = 0;
        }
        private byte[] data;
        private int position;
        public int Position
        {
            get { return position; }
        }
        public bool Eof
        {
            get { return position >= data.Length; }
        }
        public sbyte ReadSByte()
        {
            return (sbyte)data[position++];
        }
        public byte ReadByte()
        {
            return (byte)data[position++];
        }
        public int ReadInt16()
        {
            return ((data[position++] | (data[position++] << 8)));
        }
        public ushort ReadUInt16()
        {
            return (ushort)((data[position++] | (data[position++] << 8)));
        }
        public int ReadInt32()
        {
            return (((data[position++] | (data[position++] << 8)) | (data[position++] << 0x10)) | (data[position++] << 0x18));
        }
        public ulong ReadInt64()
        {
            return (ulong)(((data[position++] | (data[position++] << 8)) | (data[position++] << 0x10)) | (data[position++] << 0x18) | 
                            (data[position++] << 0x20) | (data[position++] << 0x28) | (data[position++] << 0x30) | (data[position++] << 0x38));
        }
        public double ReadDouble()
        {
            var result = BitConverter.ToDouble(data, position);
            position += 8;
            return result;
        }
        public float ReadSingle()
        {
            var result = BitConverter.ToSingle(data, position);
            position += 4;
            return result;
        }
    }
    internal class ILDecompiler
    {
        static ILDecompiler()
        {
            // Initialize our cheat tables
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
        private ILDecompiler() { }
        private static OpCode[] singleByteOpcodes;
        private static OpCode[] multiByteOpcodes;
        public static IEnumerable<ILInstruction> Decompile(MethodBase mi, byte[] ildata)
        {
            Module module = mi.Module;
            BigEndianByteReader reader = new BigEndianByteReader(ildata);
            while (!reader.Eof)
            {
                OpCode code = OpCodes.Nop;
                int offset = reader.Position;
                ushort b = reader.ReadByte();
                if (b != 0xfe)
                {
                    code = singleByteOpcodes[b];
                }
                else
                {
                    b = reader.ReadByte();
                    code = multiByteOpcodes[b];
                    b |= (ushort)(0xfe00);
                }
                object operand = null;
                switch (code.OperandType)
                {
                    case OperandType.InlineBrTarget:
                        operand = reader.ReadInt32() + reader.Position;
                        break;
                    case OperandType.InlineField:
                        if (mi is ConstructorInfo)
                        {
                            operand = module.ResolveField(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                        }
                        else
                        {
                            operand = module.ResolveField(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                        }
                        break;
                    case OperandType.InlineI:
                        operand = reader.ReadInt32();
                        break;
                    case OperandType.InlineI8:
                        operand = reader.ReadInt64();
                        break;
                    case OperandType.InlineMethod:
                        try
                        {
                            if (mi is ConstructorInfo)
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                            }
                            else
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                            }
                        }
                        catch
                        {
                            operand = null;
                        }
                        break;
                    case OperandType.InlineNone:
                        break;
                    case OperandType.InlineR:
                        operand = reader.ReadDouble();
                        break;
                    case OperandType.InlineSig:
                        operand = module.ResolveSignature(reader.ReadInt32());
                        break;
                    case OperandType.InlineString:
                        operand = module.ResolveString(reader.ReadInt32());
                        break;
                    case OperandType.InlineSwitch:
                        int count = reader.ReadInt32();
                        int[] targetOffsets = new int[count];
                        for (int i = 0; i < count; ++i)
                        {
                            targetOffsets[i] = reader.ReadInt32();
                        }
                        int pos = reader.Position;
                        for (int i = 0; i < count; ++i)
                        {
                            targetOffsets[i] += pos;
                        }
                        operand = targetOffsets;
                        break;
                    case OperandType.InlineTok:
                    case OperandType.InlineType:
                        try
                        {
                            if (mi is ConstructorInfo)
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), Type.EmptyTypes);
                            }
                            else
                            {
                                operand = module.ResolveMember(reader.ReadInt32(), mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments());
                            }
                        }
                        catch
                        {
                            operand = null;
                        }
                        break;
                    case OperandType.InlineVar:
                        operand = reader.ReadUInt16();
                        break;
                    case OperandType.ShortInlineBrTarget:
                        operand = reader.ReadSByte() + reader.Position;
                        break;
                    case OperandType.ShortInlineI:
                        operand = reader.ReadSByte();
                        break;
                    case OperandType.ShortInlineR:
                        operand = reader.ReadSingle();
                        break;
                    case OperandType.ShortInlineVar:
                        operand = reader.ReadByte();
                        break;
                    default:
                        throw new Exception("Unknown instruction operand; cannot continue. Operand type: " + code.OperandType);
                }
                yield return new ILInstruction(offset, code, operand);
            }
        }
    }
    public class ILInstruction
    {
        public ILInstruction(int offset, OpCode code, object operand)
        {
            this.Offset = offset;
            this.Code = code;
            this.Operand = operand;
        }
        public int Offset { get; private set; }
        public OpCode Code { get; private set; }
        public object Operand { get; private set; }
    }
    public class IncorrectConstraintException : Exception
    {
        public IncorrectConstraintException(string msg, params object[] arg) : base(string.Format(msg, arg)) { }
    }
    public class ConstraintFailedException : Exception
    {
        public ConstraintFailedException(string msg) : base(msg) { }
        public ConstraintFailedException(string msg, params object[] arg) : base(string.Format(msg, arg)) { }
    }
    public class NCTChecks
    {
        public NCTChecks(Type startpoint)
            : this(startpoint.Assembly)
        { }
        public NCTChecks(params Assembly[] ass)
        {
            foreach (var assembly in ass)
            {
                assemblies.Add(assembly);
                foreach (var type in assembly.GetTypes())
                {
                    EnsureType(type);
                }
            }
            while (typesToCheck.Count > 0)
            {
                var t = typesToCheck.Pop();
                GatherTypesFrom(t);
                PerformRuntimeCheck(t);
            }
        }
        private HashSet<Assembly> assemblies = new HashSet<Assembly>();
        private Stack<Type> typesToCheck = new Stack<Type>();
        private HashSet<Type> typesKnown = new HashSet<Type>();
        private void EnsureType(Type t)
        {
            // Don't check for assembly here; we can pass f.ex. System.Lazy<Our.T<MyClass>>
            if (t != null && !t.IsGenericTypeDefinition && typesKnown.Add(t))
            {
                typesToCheck.Push(t);
                if (t.IsGenericType)
                {
                    foreach (var par in t.GetGenericArguments())
                    {
                        EnsureType(par);
                    }
                }
                if (t.IsArray)
                {
                    EnsureType(t.GetElementType());
                }
            }
        }
        private void PerformRuntimeCheck(Type t)
        {
            if (t.IsGenericType && !t.IsGenericTypeDefinition)
            {
                // Only check the assemblies we explicitly asked for:
                if (this.assemblies.Contains(t.Assembly))
                {
                    // Gather the generics data:
                    var def = t.GetGenericTypeDefinition();
                    var par = def.GetGenericArguments();
                    var args = t.GetGenericArguments();
                    // Perform checks:
                    for (int i = 0; i < args.Length; ++i)
                    {
                        foreach (var check in par[i].GetCustomAttributes(typeof(ConstraintAttribute), true).Cast<ConstraintAttribute>())
                        {
                            if (!check.Check(args[i]))
                            {
                                string error = "Runtime type check failed for type " + t.ToString() + ": " + check.ToString();
                                Debugger.Break();
                                throw new ConstraintFailedException(error);
                            }
                        }
                    }
                }
            }
        }
        // Phase 1: all types that are referenced in some way
        private void GatherTypesFrom(Type t)
        {
            EnsureType(t.BaseType);
            foreach (var intf in t.GetInterfaces())
            {
                EnsureType(intf);
            }
            foreach (var nested in t.GetNestedTypes())
            {
                EnsureType(nested);
            }
            var all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            foreach (var field in t.GetFields(all))
            {
                EnsureType(field.FieldType);
            }
            foreach (var property in t.GetProperties(all))
            {
                EnsureType(property.PropertyType);
            }
            foreach (var evt in t.GetEvents(all))
            {
                EnsureType(evt.EventHandlerType);
            }
            foreach (var ctor in t.GetConstructors(all))
            {
                foreach (var par in ctor.GetParameters())
                {
                    EnsureType(par.ParameterType);
                }
                // Phase 2: all types that are used in a body
                GatherTypesFrom(ctor);
            }
            foreach (var method in t.GetMethods(all))
            {
                if (method.ReturnType != typeof(void))
                {
                    EnsureType(method.ReturnType);
                }
                foreach (var par in method.GetParameters())
                {
                    EnsureType(par.ParameterType);
                }
                // Phase 2: all types that are used in a body
                GatherTypesFrom(method);
            }
        }
        private void GatherTypesFrom(MethodBase method)
        {
            if (this.assemblies.Contains(method.DeclaringType.Assembly)) // only consider methods we've build ourselves
            {
                MethodBody methodBody = method.GetMethodBody();
                if (methodBody != null)
                {
                    // Handle local variables
                    foreach (var local in methodBody.LocalVariables)
                    {
                        EnsureType(local.LocalType);
                    }
                    // Handle method body
                    var il = methodBody.GetILAsByteArray();
                    if (il != null)
                    {
                        foreach (var oper in ILDecompiler.Decompile(method, il))
                        {
                            if (oper.Operand is MemberInfo)
                            {
                                foreach (var type in HandleMember((MemberInfo)oper.Operand))
                                {
                                    EnsureType(type);
                                }
                            }
                        }
                    }
                }
            }
        }
        private static IEnumerable<Type> HandleMember(MemberInfo info)
        {
            // Event, Field, Method, Constructor or Property.
            yield return info.DeclaringType;
            if (info is EventInfo)
            {
                yield return ((EventInfo)info).EventHandlerType;
            }
            else if (info is FieldInfo)
            {
                yield return ((FieldInfo)info).FieldType;
            }
            else if (info is PropertyInfo)
            {
                yield return ((PropertyInfo)info).PropertyType;
            }
            else if (info is ConstructorInfo)
            {
                foreach (var par in ((ConstructorInfo)info).GetParameters())
                {
                    yield return par.ParameterType;
                }
            }
            else if (info is MethodInfo)
            {
                foreach (var par in ((MethodInfo)info).GetParameters())
                {
                    yield return par.ParameterType;
                }
            }
            else if (info is Type)
            {
                yield return (Type)info;
            }
            else
            {
                throw new NotSupportedException("Incorrect unsupported member type: " + info.GetType().Name);
            }
        }
    }
