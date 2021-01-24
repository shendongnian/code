    public abstract class TableDesciptor
    {
        public abstract string TableName { get; }
    }
	
    public class AccountType<T,U>
        where T : AccountType<T,U>, new()
        where U : TableDesciptor, new()
    {
        private static string tableName = new U().TableName;
        public static List<T> AccountTypes
        {
            get
            {
                return accountTypes;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        private static List<T> accountTypes = new List<T>();
        public AccountType()
        {
        }
        public T Clone()
        {
            T o = (T)this.MemberwiseClone();
            return o;
        }
        public static T Fill(DataRow row)
        {
            int id = Convert.ToInt32(row["id"].ToString());
            string name = row["name"].ToString();
            T o = new T();
            o.Id = id;
            o.Name = name;
            return o;
        }
        public static List<T> FillAll(DataRowCollection rows)
        {
            List<T> objs = new List<T>();
            foreach (DataRow row in rows)
            {
                T o = Fill(row);
                if (o != null)
                    objs.Add(o);
            }
            return objs;
        }
        public static List<T> GetAll()
        {
            if (accountTypes.Count > 0)
                return accountTypes;
            List<T> objs = new List<T>();
            string query = "SELECT      * \r\n" +
                            "FROM   " + AccountType<T,U>.tableName + " \r\n" +
                            "WHERE      id > -1 \r\n" +
                            "ORDER BY   name";
            DataSet result = Global.Db.ExecuteQuery(query);
            if (
                        (result == null)
                    || (result.Tables[0] == null)
                    || (result.Tables[0].Rows.Count < 1)
                )
            {
                return objs;
            }
            objs = FillAll(result.Tables[0].Rows);
            return objs;
        }
        public static T GetById(int id)
        {
            foreach (T at in accountTypes)
            {
                if (at.Id== id)
                    return at;
            }
            T o = null;
            string query = "SELECT  * \r\n" +
                            "FROM   " + AccountType<T,U>.tableName + " \r\n" +
                            "WHERE  id = " + id + " \r\n";
            DataSet result = Global.Db.ExecuteQuery(query);
            if (
                        (result == null)
                    || (result.Tables[0] == null)
                    || (result.Tables[0].Rows.Count < 1)
                )
            {
                return o;
            }
            o = Fill(result.Tables[0].Rows[0]);
            return o;
        }
        public static void Load()
        {
            accountTypes = GetAll();
        }
        public void Save()
        {
            string tn = AccountType<T,U>.tableName;
            string query = "INSERT INTO " + tn + " (name) " +
                            "VALUES (               @name)";
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SQLiteParameter("@currencyPair", this.Name));
            Common.Global.Db.ExecuteNonQuery(command);
        }
        public void Update()
        {
            string query = "UPDATE " + AccountType<T,U>.tableName + " \r\n" +
                            "SET    name    = @name \r\n" +
                            "WHERE  id      = @id";
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SQLiteParameter("@id", this.Id));
            command.Parameters.Add(new SQLiteParameter("@name", this.Name));
            Common.Global.Db.ExecuteNonQuery(command);
        }
    }
