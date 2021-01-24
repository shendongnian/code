       public class Meb : IEquatable<Meb>
        {
            public int ID { get; set; }
            public int Number { get; set; }
            public int Length { get; set; }
            public int Quantity { get; set;}
            public bool Equals(Meb other)
            {
                if ((this.Number == other.Number) && (this.Length == other.Length) && (this.Quantity == other.Quantity))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return ID;
            }
        }
