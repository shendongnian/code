        public BaseClass()
        {
            //do nothing
        }
        public BaseClass(string sSql)
        {
            ExecSQL(sSql);
            //DO NOT do anything else
        }    
        public BaseClass(int i, DateTime dt)
        {
            //in base class ignore the parameters.
            string sWhereClause = "";
            string sSql = setSQL(sWhereClause);
            ExecSQL(sWhereClause);
            //DO NOT do anything else
        }
       protected virtual string setSQL(string value)
       {
           //set the sql
           string sSql = "";
           //add value into sSql
           return sSql;
       }
       protected virtual void ExecSQL(string sSql)
       {
           int i = 1;
           //execute query            
       }
    }
    public class DerivedClass: BaseClass 
    {
        //public DerivedClass(string sSql):base (sSql){}
        public DerivedClass()
        {
            //do nothing
        }
        public DerivedClass(string sSql)
        {
            ExecSQL(sSql);
           //DO NOT do anything else
        }
        public DerivedClass(int i, DateTime dt)
        {
            ExecSQL(i, dt);
            //do something else after base execution
        }
       protected void ExecSQL(int i, DateTime dt) //overloaded procedure
       {
           string sWhereClause = "";
           //construct wherclause based on i, dt
           string sSql = setSQL(sWhereClause); //calls baseclass function
           base.ExecSQL(sWhereClause); //calls baseclass procedure
       }       
    }
