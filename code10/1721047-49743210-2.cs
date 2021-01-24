    List<string> filters = Enumerable.Range(0, 101)
                                     .SelectMany(a => Enumerable.Range(0, 101).Select(b => string.Format("A{0:00}B{1:00}", a, b)))
                                     .Union(Enumerable.Range(0, 101).Select(b => string.Format("{0:000}", b)))
                                     .Union(Enumerable.Range(0, 101).Select(b => string.Format("{0:00}", b)))
                                     .Union(new List<string> { "hello" })
                                     .ToList();
