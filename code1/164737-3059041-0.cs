            List<string> items = new List<string> 
            { 
                "item 1", 
                "item 2",
                "item 3", 
                "item 4", 
            };
            lines.AsEnumerable().Reverse()
                                .Do(a => Console.WriteLine(a), ex => Console.WriteLine(ex.Message), () => Console.WriteLine("Completed"))
                                .Run();           
                 
