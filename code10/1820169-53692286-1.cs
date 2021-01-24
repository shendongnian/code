    List<TestClass> test = new List<TestClass>();
    
                test.Add(new TestClass(1, 'A', 1, 2011, 2009));
                test.Add(new TestClass(2, 'A', 1, 2011, 2010));
                test.Add(new TestClass(3, 'B', 1, 2008, 2008));
                test.Add(new TestClass(4, 'B', 1, 2009, 2009));
                test.Add(new TestClass(5, 'A', 2, 2008, 2009));
                test.Add(new TestClass(6, 'B', 1, 2008, 2011));
    
                var first_ordered = from t in test
                                    orderby t.Col2, t.Col3 descending, t.Col4 descending, t.Col5 descending
                                    group new { t.Col1, t.Col3, t.Col4, t.Col5 } by t.Col2 into p
                                    select new
                                    {
                                        Col1 = p.First().Col1,
                                        Col2 = p.Key,
                                        Col3 = p.First().Col3,
                                        Col4 = p.First().Col4,
                                        Col5 = p.First().Col5
                                    };
    
                foreach(var f in first_ordered) 
                {
                    Console.WriteLine($"{f.Col1}, {f.Col2}, {f.Col3}, {f.Col4}, {f.Col5}");
                }
