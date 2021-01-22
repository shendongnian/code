        using (Stream s = Assembly.GetEntryAssembly().GetManifestResourceStream(typeof(Program).Namespace + ".Resources." + dllName))
        {
            byte[] data = new byte[stream.Length];
            s.Read(data, 0, data.Length);
            return Assembly.Load(data);
        }
        //or just
        return Assembly.LoadFrom(dllFullPath); //if location is known.
