            MemoryStream mem = new MemoryStream(1000);
            StreamWriter writer = new StreamWriter(mem);
            Console.SetOut(writer);
            
            Assembly assembly = Assembly.LoadFrom(@"C:\ConsoleApp.exe");
            assembly.EntryPoint.Invoke(null, null);
            writer.Close();
            string s = Encoding.Default.GetString(mem.ToArray());
            mem.Close();
