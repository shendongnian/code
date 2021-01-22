    using(var writer = new BinaryWriter(new FileStream(@"D:\testlog.log", FileMode.Append, FileAccess.Write, FileShare.Read)))
    {
        int n;
        while(Int32.TryParse(Console.ReadLine(), out n))
        {
            writer.Write(n);
            writer.Flush(); // write cached bytes to file
        }
    }
