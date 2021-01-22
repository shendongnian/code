        List<string> refs = new List<string>();
        Queue<AssemblyName> pending = new Queue<AssemblyName>();
        pending.Enqueue(Assembly.GetEntryAssembly().GetName());
        while(pending.Count > 0)
        {
            AssemblyName an = pending.Dequeue();
            string s = an.ToString();
            if(refs.Contains(s)) continue; // done already
            refs.Add(s);
            try
            {
                Assembly asm = Assembly.Load(an);
                if(asm != null)
                {
                    foreach(AssemblyName sub in asm.GetReferencedAssemblies())
                    {
                        pending.Enqueue(sub);
                    }
                    foreach (Type type in asm.GetTypes())
                    {
                        foreach (MethodInfo method in type.GetMethods(
                            BindingFlags.Static | BindingFlags.Public |
                                 BindingFlags.NonPublic))
                        {
                            DllImportAttribute attrib = (DllImportAttribute)
                                Attribute.GetCustomAttribute(method,
                                    typeof(DllImportAttribute));
                            if (attrib != null && !refs.Contains(attrib.Value))
                            {
                                refs.Add(attrib.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
        refs.Sort();
        foreach (string name in refs)
        {
            Console.WriteLine(name);
        }
