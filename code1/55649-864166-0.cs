    using (BinaryReader reader = new BinaryReader(
        assembly.GetManifestResourceStream(@"Namespace.Resources.File.ext")))
    {
        using (BinaryWriter writer
            = new BinaryWriter(new FileStream(path, FileMode.Create)))
        {
            byte[] buffer = new byte[64 * 1024];
            int numread = reader.Read(buffer,0,buffer.Length);
    
            while (numread > 0)
            {
                writer.Write(buffer,0,numread);
                numread = reader.Read(buffer,0,buffer.Length);
            }
            writer.Flush();
        }
    }
