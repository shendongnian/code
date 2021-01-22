    public sealed class LikeEnum
    {
        public static readonly LikeEnum One = new LikeEnum("one");
        public static readonly LikeEnum Two = new LikeEnum("Two");
    
        private string value;
    	private LikeEnum(string v)
    	{
    		value = v;
    	}
    }
