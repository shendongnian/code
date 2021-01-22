        AppDomain.CurrentDomain.AssemblyLoad += (s, a) =>
        {
            Console.WriteLine(a.LoadedAssembly.FullName);
            Console.WriteLine(a.LoadedAssembly.CodeBase);
        };
