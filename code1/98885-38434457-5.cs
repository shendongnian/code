        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int Price { get; set; }
            public override bool Equals(object obj)
            {
                if (!(obj is Item))
                    return false;
                Item p = (Item)obj;
                return (p.Id == Id && p.Name == Name && p.Code == Code && p.Price == Price);
            }
            public override int GetHashCode()
            {
                return String.Format("{0}|{1}|{2}|{3}", Id, Name, Code, Price).GetHashCode();
            }
        }
