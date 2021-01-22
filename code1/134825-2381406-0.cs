        var source = Enumerable.Range(1, 100).Cast<int?>().ToArray();
        int indexToRemove = 4;
        var s = new Stopwatch();
        s.Start();
        for (int i = 0; i < 1000000; i++)
        {
            Array.Copy(source, indexToRemove + 1, source, indexToRemove, source.Length - indexToRemove - 1);
            //for (int index = indexToRemove; index + 1 < source.Length; index++)
            //    source[index] = source[index + 1]; 
        }
        s.Stop();
        Console.WriteLine(s.Elapsed);
