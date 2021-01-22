    public class User
    {
        public static List<User> GetAllUsers()
        {
            DataAccessWrapper daw = new DataAccessWrapper();
            return (List<User>)(daw.ExecuteDataReader("MyProc", new ReaderDelegate(ReadList)));
        }
        protected static object ReadList(SQLDataReader dr)
        {
            List<User> retVal = new List<User>();
            while(dr.Read())
            {
                User temp = new User();
                temp.Prop1 = dr.GetString("Prop1");
                temp.Prop2 = dr.GetInt("Prop2");
                retVal.Add(temp);
            }
            return retVal;
        }
    }
