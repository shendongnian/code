    public class Foo
    {
        public int Id { get; set; }
        // other properties here
        // ......
    
        public override int GetHashCode()
        {
            int hash = 37;
            hash = hash * 23 + typeof(Foo).GetHashCode();
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }
    }
