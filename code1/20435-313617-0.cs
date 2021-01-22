    public class TableInfo
    {
         private IMapinfoWrapper wrapper;
         public TableInfo() : this(null) {}
         public TableInfo( IMapinfoWrapper wrapper )
         {
              // use from cache if not supplied
              this.wrapper = wrapper ?? Publics.InternalMapInfo;
         }
         public string Name {
            get { return wrapper.Eval("String comman to get the name"); }
            set { wrapper.Do("String command to set the name"); }
         }
    }
    public interface IMapinfoWrapper
    {
        void Do( string cmd );
        void Eval( string cmd );
    }
    public class MapinfoWrapper 
    {
        public MapinfoWrapper()
        {
        }
    
        public void Do(string cmd) 
        {
            //Call COM do command
        }
    
        public string Eval(string cmd)
        {
            //Return value from COM eval command
        }
    }
    internal static class Publics
    {
        private static MapinfoWrapper _internalwrapper;
        internal static MapinfoWrapper InternalMapinfo 
        { 
            get
            {
                if (_internalwrapper == null)
                {
                    _internalwrapper = new MapinfoWrapper();
                }
                return _internalwrapper;     
            }
        }
    }
