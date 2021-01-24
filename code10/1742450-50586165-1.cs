    public static void MergeFiles(string output, params string[] inputs)
    {
        var files = inputs.Select(File.ReadLines).Select(iter => iter.GetEnumerator()).ToArray();
        StringBuilder line = new StringBuilder();
        bool any;
        using (var outFile = File.CreateText(output))
        {
            do
            {
                line.Clear();
                any = false;
                foreach (var iter in files)
                {
                    if (!iter.MoveNext())
                        continue;
                    if (line.Length != 0)
                        line.Append(", ");
                    line.Append(iter.Current);
                    any = true;
                }
                if (any)
                    outFile.WriteLine(line.ToString());
            }
            while (any);
        }
        foreach (var iter in files)
        {
            iter.Dispose();
        }
    }
