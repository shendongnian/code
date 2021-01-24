    public class VModel
    {
        public ICommand Clicked { get; set; }
        public DataView Library { get; private set; }
        public VModel()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection("SERVER=localhost;" + "DATABASE=library;" + "UID=root;" + "PASSWORD=;"))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand("select * from movie_list", connection);
                adapter.Fill(dt);
            }
            var Library = dt.DefaultView;
            var Clicked = new ClickedCommand(this);
        }
    }
