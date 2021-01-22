    // Windows Forms:
    // C#: The static contructor of the 'Program' class in Program.cs
    // VB.Net: 'MyApplication' class in ApplicationEvents.vb (Project Settings-->Application Tab-->View Application Events)
    // WPF:
    // The 'App' class in WPF applications (app.xaml.cs/vb)
    
    static Program() // Or MyApplication or App as mentioned above
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.Contains("Mydll"))
        {
            // Looking for the Mydll.dll assembly, load it from our own embedded resource
            foreach (string res in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if(res.EndsWith("Mydll.dll"))
                {
                    Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(res);
                    byte[] buff = new byte[s.Length];
                    s.Read(buff, 0, buff.Length);
                    return Assembly.Load(buff);
                }
            }
        }
        return null;
    } 
