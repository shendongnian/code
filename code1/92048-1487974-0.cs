    public class Foo
    {
        public Foo()
        {
            // Note uppercase on BGroup to access the property and 
            //   not its backing field.
            BGroup = new BoolGroup(); 
        }
    
        private BoolGroup bGroup;
        public BoolGroup BGroup
        {
            get{ return this.bGroup; }
            set
            { 
                this.bGroup = value;
                this.doSomething();
            }
        }
    }
