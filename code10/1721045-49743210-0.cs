    List<string> filters = Enumerable.Range(0, 101)
                                     .SelectMany(a => Enumerable.Range(0, 101).Select(b => $"A{a:00}B{b:00}"))
                                     .Union(Enumerable.Range(0, 101).Select(b => $"{b:000}"))
                                     .Union(Enumerable.Range(0, 101).Select(b => $"{b:00}"))
                                     .Union(new List<string> {"hello"})
                                     .ToList();
