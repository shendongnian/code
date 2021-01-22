        public class Box
        {
            public ToyType MaxType { get; set; }
            public List<Toy> Toys = new List<Toy>();
            public void Add(Toy toy)
            {
                if (toy.Type.Size <= MaxType.Size) //if its not larger, or whatever compatibility test you want
                    Toys.Add(toy);
            }
        }
        public class Toy
        {
            public ToyType Type { get; set; }
            public Toy(ToyType type)
            {
                Type = type;
            }  
        }
        public abstract class ToyType
        {
            public abstract string TypeName { get; set; }
            public abstract int Size { get; set; }
        }
