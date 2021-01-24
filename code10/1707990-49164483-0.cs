    var a = Convert.ToByte('a');
    var one = Convert.ToByte("1", 16); // If you want to provide the base
    using (var writer = new BinaryWriter(File.Open("Path", FileMode.Create)))
    {
        writer.Write(a);
        writer.Write(one);
        writer.Write("X"[0]);
    }
    using (var reader = new BinaryReader(File.Open("Path", FileMode.Open)))
    {
        var aa = (char)reader.ReadByte();
        Console.WriteLine(aa);
        var oneOne = (char)reader.ReadByte();
        var x = (char)reader.ReadByte();
    }
