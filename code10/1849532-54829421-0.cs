    fileLines
        = System.IO.File.ReadAllLines(fileName)
                        .AsParallel()
                        .Skip(1)
                        .Take(fileLines.Count())
                        .Concat(fileLines.Last().Contains(item.sym) ? Enumerable.Empty
                                                                    : new string[]{ item.sym });
                        .ToList();
