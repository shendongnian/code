    public abstract class Base<T>
        where T : Base<T>, new()
    {
        #region Singleton Instance
        //This is to mimic static implementation of non instance specific methods
        private static object lockobj = new Object();
        private static T _Instance;
        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockobj)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new T();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion //Singleton Instance
        #region Abstract Definitions
        public abstract T GetByID(long id);
        public abstract T Fill(SqlDataReader sr);
        #endregion //Abstract Definitions
    }
    public class InstanceClass : Base<InstanceClass>
    {
        //empty constructor to ensure you just get the method definitions without any
        //additional code executing
        public InstanceClass() { }
        #region Base Methods
        public override InstanceClass GetByID(long id)
        {
            SqlDataReader sr = DA.GetData("select * from table");
            return InstanceClass.Instance.Fill(sr);
        }
        internal override InstanceClass Fill(SqlDataReader sr)
        {
             InstanceClass returnVal = new InstanceClass();
             returnVal.property = sr["column1"];
             return returnVal;
        }
    }
