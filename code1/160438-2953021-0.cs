    IEnumerable<int[]> GetArrays(string filename, bool skipFirstLine)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            if (skipFirstLine && !reader.EndOfStream)
                reader.ReadLine();
    
            while (!reader.EndOfStream)
            {
                string temp = reader.ReadLine();
                int[] array = temp.Trim().Split().Select(s => int.Parse(s)).ToArray();
                yield return array;
            }
        }
    }
    
    int[][] GetAllArrays(string filename, bool skipFirstLine)
    {
        int skipNumber = 0;
        if (skipFirstLine )
            skipNumber = 1;
        int[][] array = File.ReadAllLines(filename).Skip(skipNumber).Select(line => line.Trim().Split().Select(s => int.Parse(s)).ToArray()).ToArray();
        return array;
    }
