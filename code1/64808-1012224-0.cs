        StringDictionary data = new StringDictionary();
        Random rand = new Random(123456);
        for (int i = 0; i < 1000000; i++)
        {
            data.Add("Key " + i, "Value = " + rand.Next());
        }
        Stopwatch watch = Stopwatch.StartNew();
        using (TextWriter output = File.CreateText("foo.txt"))
        {
            foreach (DictionaryEntry pair in data)
            {
                output.Write((string)pair.Key);
                output.Write('\t');
                output.WriteLine((string)pair.Value);
            }
            output.Close();
        }
        watch.Stop();
