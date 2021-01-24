    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetDB();
        }
        void GetDB1()
        {
            var DBFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DB1");
            var con = new System.Data.SQLite.SQLiteConnection($"Data Source={DBFile}.sqlite;Version=3;");
            con.Open();
            string sql = "Select 1 as col1";
            var command = new System.Data.SQLite.SQLiteCommand(sql, con);
            var reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("col1: " + reader["col1"]);
        }
    }
