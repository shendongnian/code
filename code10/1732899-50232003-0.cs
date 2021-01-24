            var allLines = File.ReadAllLines(@"d:\name.txt").ToList();
            IEnumerable<int> allIndices = allLines.Select((s, i) => new { Str = s, Index = i })
                        .Where(x => x.Str == "David")
                        .Select(x => x.Index);
            foreach (int matchingIndex in allIndices.Reverse())
            {
                allLines.Insert(matchingIndex, "find my name");
            }          
            File.WriteAllLines(@"d:\name.txt", allLines.ToArray());
