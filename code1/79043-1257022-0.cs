    public abstract class MyBaseClass
    {
        internal MyBaseClass() { }
        private static Hashtable _hashtable;
        protected static Hashtable hashtable
        {
            get
            {
                if(_hashtable == null)
                {
                    _hashtable = Hashtable.Synchronized(new Hashtable());
                }
                return _hashtable;
            }
        }
    }
