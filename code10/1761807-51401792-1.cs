    public class SomeImplementation : CollectionPipe<string, char[]>
    {
    
        public SomeImplementation() : base(/*something here*/)
        {
        }
    
        protected override char[] ProcessOne(string input)
        {
            return input.ToCharArray();
        }
    }
