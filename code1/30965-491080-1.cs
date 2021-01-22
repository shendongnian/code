    public class ThreadSafeDictionary
    {
        private Dictionary<string, int> dict = new Dictionary<string, int>();
        private object padlock = new object();
        
        public void AddItem( string key, int value )
        {
            lock ( padlock )
            {
                if( !dict.ContainsKey( key ) )
                    dict.Add( key, value );
            }
        }
    }
