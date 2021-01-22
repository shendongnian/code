    public class LikeEnum
    {
        public static readonly LikeEnum One = new LikeEnum("One");
        public static readonly LikeEnum Two = new LikeEnum("Two");
        
        private string value;
        
        private LikeEnum(string value)
        {
            this.value = value;
        }
    }
