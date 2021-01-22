    using(FileStream stream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
    {
        DataSet ds = new DataSet();
        ds.ReadXml(stream);
        DataTable table = ds.Tables[0];
        DataRow[] rows = table.Select("Inventory== 1");
        DataRow row = rows[0];
        row["Inventory"] = "2";
        // Reset the stream here to the beginning of the file!
        stream.Seek(0, SeekOrigin.Begin);
        ds.WriteXml(stream);
        // Reset the length of the stream prior to closing it, in case it's shorter than it used to be...
        stream.SetLength(stream.Position);
    }
