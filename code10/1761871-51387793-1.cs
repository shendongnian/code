    using (var fstream = new FileStream(..., FileMode.Create)
    using (var writer = new BinaryWriter(fstream))
    {
        // Write headers
        writer.Write(Encoding.ASCII.GetBytes("..."));
        // Write binary data
    }
