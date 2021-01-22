    public class Outer
    {
        private Outer(Builder builder)
        {
            // Copy stuff
        }
    
        public class Builder
        {
            public Outer Builder()
            {
                return new Outer(this);
            }
        }
    }
