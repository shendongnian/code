    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace LinqDemo
    {
        class Program
        {
            static void Main()
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                File.WriteAllLines(
                    Path.Combine(baseDir, "out.txt"),
                    File.ReadAllLines(Path.Combine(baseDir, "in.txt"))
                        .Select(line => new KeyValuePair<string, string[]>(line, line.Split(','))) // split each line into columns, also carry the original line forward
                        .Where(info => info.Value.Length > 1) // filter out lines that don't have 2nd column
                        .Select(info => new KeyValuePair<string, int>(info.Key, int.Parse(info.Value[1]))) // convert 2nd column to int, still carrying the original line forward
                        .Where(info => info.Value == 24809) // apply the filtering criteria
                        .Select(info => info.Key) // restore original lines
                        .ToArray());
            }
        }
    }
