    public static Assembly LoadAssembly(string assembly, Evidence evidence)
    {
        Assembly asm;
        Type assmType = typeof(Assembly);
        Type[] argTypes = new Type[] {typeof(string), typeof(Evidence)};
        MethodInfo load = assmType.GetMethod("Load", argTypes);
        bool evidenceSupported = (!Attribute.IsDefined(load, typeof(ObsoleteAttribute)));
        if (evidenceSupported)
        {
            asm = Assembly.Load(assembly, evidence);
        }
        else
        {
            asm = Assembly.Load(assembly);
        }
        return asm;
    }
