    int[,] constants;
    if(!File.Exists("constants.bin")) {
        GenerateConstants();
        
        Stream stream = new FileStream("constants.bin", FileMode.Create, FileAccess.Write, FileShare.None);
        new BinaryFormatter.Serialize(stream, constants);
        stream.Close();
    }
    else
    {
        Stream stream = new FileStream("constants.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
        constants = (int[,])(new BinaryFormatter.Deserialize(stream));
        stream.Close();
    }
