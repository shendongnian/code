    new CompilerParameters
    {
        ReferencedAssemblies =
        {
            typeof(MyDll1.Type1).Assembly.Location,
            typeof(MyDll2.Type2).Assembly.Location
            //, etc
        }
        //, etc
    }
