        using (var lines = File.ReadLines("c:\\file.txt").GetEnumerator())
        {
            while (lines.MoveNext())
            {
                string firstLine = lines.Current;
                if (!lines.MoveNext())
                    throw new InvalidOperationException("odd nr of lines");
                string secondLine = lines.Current;
                // use 2 lines
                // ...
            }
        }
