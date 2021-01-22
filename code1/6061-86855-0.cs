    using (StreamReader reader = file.OpenText())
    {
       List<string> text = new List<string>();
       while (!reader.EndOfStream)
       {
          text.Add(reader.ReadLine());
       }
    }
