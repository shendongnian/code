    using (BinaryWriter writer = new BinaryWriter(fileStream)) {
       writer.Write(1);
       writer.Write(1.0);
       writer.Write(true);
       writer.Write("Hello");
    }
