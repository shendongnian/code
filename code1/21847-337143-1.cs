    public class Outer
    {
        private Outer(Builder builder)
        {
            // Copy stuff
        }
    
        public class Builder
        {
            public Outer Build()
            {
                return new Outer(this);
            }
        }
    }
