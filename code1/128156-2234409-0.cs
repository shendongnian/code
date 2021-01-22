    // assembly is Assembly containing the resource
    // path is string containing path to write to
    Stream source = assembly.GetManifestResourceStream("Namespace.filename.mdb");
    BinaryReader br = new BinaryReader(source);
    BinaryWriter bw = new BinaryWriter(path, FileMode.Create);
    byte[] buffer = new byte[256];
    int count = 0;
    while((count = br.Read(buffer, 0, 256)) > 0) {
        bw.Write(buffer, 0, count);
    }
