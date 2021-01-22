    public partial class Partial : ICloneable
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public object Clone()
        {
            return Clone(true);
        }
    }
    public partial class Partial
    {
        public Partial Clone(bool deep)
        {
            var copy = new Partial();
            // All value types can be simply copied
            copy.Id = Id; 
            copy.Name = Name; 
            return copy;
        }
    }
