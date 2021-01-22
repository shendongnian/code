        abstract class BaseFunctionality
        {
            public abstract string MethodName(int id, string parameter);
        }
        class Admin : BaseFunctionality
        {
            public override string MethodName(int id, string parameter)
            {
                return "dbcall.Execute()";
            }                        
        }
        class Front : BaseFunctionality
        {
            public override string MethodName(int id, string parameter)
            {
                return "dbcall.ExecuteMe()";
            }
        }
