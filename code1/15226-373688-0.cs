    public class Globals
    {
        private string setting1;
        private string setting2;
    
        #region Singleton Pattern Implementation
    
        private class SingletonCreator
        {
            internal static readonly Globals uniqueInstance = new Globals();
    
            static SingletonCreator()
            {
            }
        }
    
        /// <summary>Private Constructor for Singleton Pattern Implementaion</summary>
        /// <remarks>can be used for initializing member variables</remarks>
        private Globals()
        {
    
        }
    
        /// <summary>Returns a reference to the unique instance of Globals class</summary>
        /// <remarks>used for getting a reference of Globals class</remarks>
        public static Globals GetInstance
        {
            get { return SingletonCreator.uniqueInstance; }
        }
    
        #endregion
    
        public string Setting1
        {
            get { return this.setting1; }
            set { this.setting1 = value; }
        }
    
        public string Setting2
        {
            get { return this.setting2; }
            set { this.setting2 = value; }
        }
    
        public static int Constant1 
        {
            get { reutrn 100; }
        }
    
        public static int Constat2
        {
            get { return 200; }
        }
    
        public static DateTime SqlMinDate
        {
            get { return new DateTime(1900, 1, 1, 0, 0, 0); }
        }
    
    }
