    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Fill_Combo();
        }
        public void Fill_Combo()
        {
            Connection2DB cst = new Connection2DB();
            cmbBoxId.Items.AddRange(cst.Select().ToArray());
        }
    }
    class Connection2DB
    {
        public List<string> Select()
        {
            var ids = new List<string>();
            try
            {
                string sqlqry = "select ID from Customer";
                SqlCommand cmds = new SqlCommand(sqlqry, _con);
                SqlDataReader dr = cmds.ExecuteReader();
                while (dr.Read())
                {
                    ids.Add(dr["ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
            }
            return ids;
        }
    }
