    public static void parseCustomAttribute(Cci::ICustomAttribute customAttribute)
    { 
        foreach (Cci::IMetadataNamedArgument namedArg in customAttribute.NamedArguments)
        { 
            parseNamedArgument(namedArg);
        }
        foreach (Cci::IMetadataExpression arg in customAttribute.Arguments)
        {
            parseFixedArgument(arg);
        }
        Console.WriteLine("Type Reference:\t\t"+ customAttribute.Type.ToString());
        var constructor = customAttribute.Constructor as Cci::IMethodDefinition;
        if (constructor != null)
        {
            //parseMethodDefinition(constructor);
        }
        else
        {
            //parseMethodReference(constructor);
        }
    }
    private static void parseFixedArgument(Cci::IMetadataExpression fixedArgument)
    {
        Console.WriteLine("Type Reference:\t\t" + fixedArgument.Type.ToString());
        var constValue = fixedArgument as Cci::IMetadataConstant;
        if (constValue != null)
        {
            Console.WriteLine("Value :"  + constValue.Value);
        }
    }
    private static void parseNamedArgument(Cci::IMetadataNamedArgument namedArg)
    {
        Console.WriteLine("Name:" + "\t\t" + namedArg.ArgumentName.Value);
        parseFixedArgument(namedArg.ArgumentValue);
    }
