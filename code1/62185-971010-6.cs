    // serialize the object to disk
    BinaryFormatter formatter = new BinaryFormatter();
    using (Stream stream = File.OpenWrite(@"c:\temp\dirlist.data"))
    {
        formatter.Serialize(stream, dirs);
    }
    // at some other point, when you want to deserialize
    BinaryFormatter formatter = new BinaryFormatter();
    List<string> dirList;
    using (Stream stream = File.OpenRead(@"c:\temp\dirlist.data"))
    {
        dirList = (List<string>)formatter.Deserialize(stream);
    }
