    public class RepositorySql : IRepository
    {
        public object GetModel(int id) 
        {
            // TODO: Call a stored procedure and depending on the procedure you are 
            // calling return a different anonymous type, for example:
            return new 
            {
                Column1 = "value1",
                Column2 = "value2",
            }
        }
    }
