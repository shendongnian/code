    // My naive C# attempt:P
    public class Property 
    {
        public static void main( String []args ) 
        {
             Property p = Property.buildFrom( new Builder("title").Area("area").Etc() )
        }
        public static Property buildFrom( Builder builder ) 
        {
            return new Propert( builder );
        }
        private Property ( Builder builder ) 
        {
            this.area = builder.area;
            this.title = builder.title;
            // etc. 
        }
    }
    public class Builder 
    {
        public Builder ( String t ) 
        {
           this.title = t;
        }
        public Builder Area( String area )
        {
           this.area = area;
           return this;
        }
        // etc. 
    }
