    using (BinaryWriter writer = 
        new BinaryWriter(File.Open("data.txt", FileMode.Create)))
    {
        writer.Write("one,1,1,1,1");
        writer.Write("two,2,2,2,2");
        writer.Write("three,3,3,3,3");
    }
