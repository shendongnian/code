    public class NoPublicConstructor
    {
        private NoPublicConstructor()
        {
        }
    
        public static NoPublicConstructor NewInstance()
        {
            return new NoPublicConstructor();
        }
    }
