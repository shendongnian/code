    IInstructionWithOperand GetInstruction(string opcode)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        Console.WriteLine(operands[0]);
        foreach (Assembly a in assemblies)
        {
            Type[] typeArray = a.GetTypes();
            foreach (Type type in typeArray)
            {
                if (opcode.Equals(type.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    Object dynamicObj = Activator.CreateInstance(type);
                    return (IInstructionWithOperand)dynamicObj;
                }
            }
        }
    } 
