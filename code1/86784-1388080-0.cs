    using(BinaryReader reader = new BinaryReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ResourceBlenderExpress.Resources.images.flags.tr.png")))
    using(BinaryWriter writer = new BinaryWriter(File.OpenWrite(imageFile))) 
    {
        while((read = reader.Read(buffer, 0, buffer.Length)) > 0) 
        {
            writer.Write(buffer, 0, read);
        }
    }
