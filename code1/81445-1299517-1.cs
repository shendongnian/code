    public class Foo
    {
        private readonly TriggerField<string> flibble = new TriggerField<string>();
        private int versionCount = 0;
    	
        public Foo()
        {
            flibble.OnSet += (old,current) => this.versionCount++;  
        }
    	
        public string Flibble 
        { 
            get { return this.flibble.Value; }
            set { this.flibble.Value = value; }
        }
    }
