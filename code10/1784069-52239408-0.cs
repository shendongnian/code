        internal static Assembly GetMissingAssembly(
            object s, 
            ResolveEventArgs e)
        {
            Assembly oResult = null;
            if (!e.Name.ToLower().Contains("resources"))
            {
                string Name = e.Name; //e.Name is read-only
                if (moAssemblies != null && moAssemblies.Count > 0)
                {
                    if (moAssemblies.ContainsKey(Name)) oResult = moAssemblies[Name];
                    if (oResult == null) throw new Exception("Could not load assembly " + Name);
                }
            }
            return oResult;
        }
