            class Foo
            {
                public DateTime Date { get; set; }
            }
    
            var foos = new[] 
                {
                    new Foo { Date = DateTime.Now },
                    new Foo { Date = new DateTime(2009, 7, 3)},
                    new Foo { Date = new DateTime(2009, 6, 20)},
                    new Foo { Date = new DateTime(2009, 6, 21)},
                    new Foo { Date = new DateTime(2009, 7, 2)}
                };
    
                var query = from foo in foos
                            group foo by foo.Date.AddDays(-(int)foo.Date.DayOfWeek) into g
                            select new
                            {
                                Count = g.Count(),
                                Date = g.Key
                            };
    
                foreach (var foo in query)
                    Console.WriteLine("People count: {0} Date: {1}", foo.Count, foo.Date);
