    public static class Extension
    {
        public static bool IsGenericList(this object o)
        {
           return IsGeneric((dynamic)o);
        }
        public static bool IsGeneric<T>(List<T> o)
        {
           return true;
        }
        public static bool IsGeneric( object o)
        {
            return false;
        }
    }
	
	
    var l = new List<int>();
    l.IsGenericList().Should().BeTrue();
    var o = new object();
    o.IsGenericList().Should().BeFalse();
