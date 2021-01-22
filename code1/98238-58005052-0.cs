    private void LoadAssemblyPlugins(string dll)
        Assembly ass = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => new Uri(a.CodeBase).Equals(new Uri(dll)));
       if (ass == null)
           // Load it here
           // use activator here
