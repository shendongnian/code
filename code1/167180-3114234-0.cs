    try {
        using (Stream stream = File.Open(cfgFile, FileMode.Create, FileAccess.Write)) {
            try {
              IFormatter formatter = new BinaryFormatter();
              formatter.Serialize(stream, obj);
            } catch (SerializationException err) {
              Console.WriteLine(err);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception: {0}", ex);
    }
