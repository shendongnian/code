           var p = new Parser()
            {
                Steps =
                {
                    new ParserStep()
                    {
                        Data = { Tuple.Create("AOC", "Add On Card") },
                        ToDo = (a => Console.WriteLine($"Product Family = {a}")),
                        Optional = false
                    },
                    new ParserStep()
                    {
                        Data =
                        {
                            Tuple.Create("S", "Standard"),
                            Tuple.Create("P", "Proprietary"),
                            Tuple.Create("C", "MicroLP"),
                            Tuple.Create("MH", "SIOM Hybrid"),
                            Tuple.Create("M", "Super IO")
                        },
                        ToDo = (a => Console.WriteLine($"Form Factor = {a}")),
                        Optional = false
                    }
                }
            };
