    using (TextWriter dest = File.CreateText("out.txt"))
    {
        for (int i = 0; i < 100000; i++)
        {
            dest.Write(i);
            dest.Write(": ");
            dest.WriteLine(i % 5000); // why not
        }
    }
