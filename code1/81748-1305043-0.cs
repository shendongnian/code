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
