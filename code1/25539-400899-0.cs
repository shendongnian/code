    using (StreamWriter SW = new StreamWriter(FS))
    {
        for (int i = 0; i < Output.Length; i++)
        {
            SW.WriteLine(Output[i]);
        }
    }
