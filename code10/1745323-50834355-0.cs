    public sealed partial class MainPage : Page
    { 
        private void btngettest_Click(object sender, RoutedEventArgs e)
        {
            List<String> ids = sqlhelp.GetData();
            string idfromjson = "2";
            foreach (string id in ids)
            {
                if (id != idfromjson)
                {
                    //do insert operation
                }
                else
                {
                    //do nothing
                }
            } 
        } 
    }
    public class sqlhelp
    {
        public static void InitializeDatabase()
        {
           ... 
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT id from MyTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
