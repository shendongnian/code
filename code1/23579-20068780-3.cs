    public class Foo
    {
        public int FooId { get; set; }
        public string FooName { get; set; }
    
        public override bool Equals(object obj)
        {
            Foo fooItem = obj as Foo;
            if (fooItem == null)
            {
               return false;
            }
    
            return fooItem.FooId == this.FooId;
        }
    
        public override int GetHashCode()
        {
            // Some comment to explain if there is a real problem with providing GetHashCode() 
            // or if I just don't see a need for it for the given class
            throw new Exception("Sorry I don't know what GetHashCode should do for this class");
        }
    }
