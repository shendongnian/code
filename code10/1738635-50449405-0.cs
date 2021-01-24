    public class Item : IEquatable<Item>
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int? Price { get; set; }
            public bool Equals(Item Other)
            {
                //Check whether the compared object is null. 
                if (Object.ReferenceEquals(Other, null)) return false;
                //Check whether the compared object references the same data. 
                if (Object.ReferenceEquals(this, Other)) return true;
                //Check whether the products' properties are equal. 
                return this.Id == Other.Id;
            }
            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }
        }
    List<Item> a = new List<Item>
            {
               new Item {Id = 1, Name = "Item1", Code = "IT00001", Price = 100},
               new Item {Id = 2, Name = "Item2", Code = "IT00002", Price = 200},
               new Item {Id = 3, Name = "Item3", Code = "IT00003", Price = 150},
               new Item {Id = 1, Name = "Item1", Code = "IT00001", Price = 100},
               new Item {Id = 3, Name = "Item3", Code = "IT00003", Price = 150},
               new Item {Id = 3, Name = "Item3", Code = "IT00004", Price = 250}
            };
            var b = a.Distinct().ToList();
