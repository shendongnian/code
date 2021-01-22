        List<Item> a = new List<Item>
        {
            new Item {Id = 1, Name = "Item1", Code = "IT00001", Price = 100},
            new Item {Id = 2, Name = "Item2", Code = "IT00002", Price = 200},
            new Item {Id = 3, Name = "Item3", Code = "IT00003", Price = 150},
            new Item {Id = 1, Name = "Item1", Code = "IT00001", Price = 100},
            new Item {Id = 3, Name = "Item3", Code = "IT00003", Price = 150},
            new Item {Id = 3, Name = "Item3", Code = "IT00004", Price = 250}
        };
        var distinctItems = a.GroupBy(x => x.Id).Select(y => y.First());
