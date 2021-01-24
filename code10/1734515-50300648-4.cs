        var schedules = new List<Item>{
            new Item { Id=1, Name = "S" },
            new Item { Id=2, Name = "P" },
            new Item { Id=3, Name = "X" },
            new Item { Id=4, Name = "X" },
            new Item { Id=5, Name = "P" },
            new Item { Id=6, Name = "P" },
            new Item { Id=7, Name = "P" },
            new Item { Id=8, Name = "S" }
        };
        var results = schedules
            .GroupWhile((preceding, next) => preceding.Name == next.Name) 
            //Group items, while the next is equal to the preceding one
            .Where(s => s.Count() > 1)
            //Only include results where the generated sublist have more than 1 element.
            .ToList();
        foreach (var sublist in results)
        {
            foreach (Item i in sublist)
            {
                Console.WriteLine($"{i.Name} - {i.Id}");
            }
            Console.WriteLine("");
        }
        Console.ReadLine();
