    using (TextReader reader = File.OpenText("test.txt"))
    {
        int x = int.Parse(reader.ReadLine());
        double y = double.Parse(reader.ReadLine());
        string z = reader.ReadLine();
    }
