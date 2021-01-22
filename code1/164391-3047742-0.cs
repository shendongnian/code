    static void Main(string[] args)
            {
                var s = new List<Animal>
                            {
                                new Animal {Value = "Zebra"},
                                new Animal {Value = "Zebra"},
                                new Animal {Value = "Cobra"},
                                new Animal {Value = "Apple"}
                            };
    
                var result = from a in s
                             orderby a.Value
                             group a by a.Value into b
                             select b;
    
                foreach (var group in result)
                {
                    foreach (var animal in group)
                    {
                        Console.WriteLine(animal.Value);
                    }
                }             
            }
    class Animal
    {
        public string Value { get; set;}
    }
