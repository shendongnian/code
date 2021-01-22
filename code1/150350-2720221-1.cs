    public class SomeClass
    {
        private StringBuilder stringBuilder;
    
        // Property declaration
        public StringBuilder StringBuilder
        {
            get 
            { 
                if(this.stringBuilder == null)
                    this.stringBuilder = new StringBuidler();
    
                return this.stringBuilder;
            }
            set
            {
                if(this.stringBuilder == null)
                    this.stringbuilder = value;
            }
        }
    }
