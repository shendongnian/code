        public BaseClass(string sSql)
        {
            ExecSQL(sSql);
            //execute query
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass(int i, DateTime dt)
        {
            string sSql = "";
            //construct sSql based on i, dt
            base(sSql);
            //do something else
        }
    }      
