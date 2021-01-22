    string GetAssemblyTitle(Assembly assembly)
    {
        object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length == 1)
        {
            return (attributes[0] as AssemblyTitleAttribute).Title;
        }
        else
        {
            // Return the assembly name if there is no title
            return this.GetType().Assembly.GetName().Name;
        }
    }
