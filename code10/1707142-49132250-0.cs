     class Data
            {
                public string Id { get; set; }
                public long Power { get; set; }
                public int Count { get; set; }
            }
            var listoflist = new List<Data>
            {
                new Data {Id = "#1", Power = 2, Count = 10},
                new Data {Id = "#2", Power = 3, Count = 2},
                new Data {Id = "#3", Power = 4, Count = 5}
            };
            var ascending = true; // ascending
            var mult = ascending ? 1 : -1;
            listoflist.Sort((a, b) => mult * a.Count.CompareTo(b.Count));
