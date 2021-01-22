    class ApplicationProxy : MarshalByRefObject
    {
        public void DoSomething()
        {
            Assembly oldVersion = Assembly.Load(new AssemblyName()
            {
                CodeBase = @"c:\yourfullpath\AssemblyFile.dll"
            });
            Type yourOldClass = oldVersion.GetType("namespace.class");
            // this is an example: your need to correctly define parameters below
            yourOldClass.InvokeMember("OldMethod", 
                                       BindingFlags.Public, null, null, null);
        }
    }
