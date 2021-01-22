    Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
    using (System.IO.Stream s = asm.GetManifestResourceStream(<yourname>)
    {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(s))
        {
            string xml = reader.ReadToEnd();
        }
    }
