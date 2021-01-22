    namespace enable
    {    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                OleDbConnection favouriteConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\192.168.123.5\\Share\\Matt\\BugTypes.mdb");
                string strSQL = "SELECT CategoryName, Show " + "FROM [Categories] WHERE Show = 'Yes' " + "ORDER BY CategoryName";
                m_Adapter = new OleDbDataAdapter(strSQL, favouriteConnection)l
                OleDbCommandBuilder cBuilder = new OleDbCommandBuilder(m_Adapter);
                dTable = new DataTable();
                m_Adapter.Fill(dTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dTable;
                dataGridView1.DataSource = bSource;
                m_Adapter.Update(dTable);            
            }
            private void button1_Click(object sender, EventArgs e)
            {
                m_Adapter.Update(dTable);//this is the button that needs to do the save, but can't see the variables.
            }
            OleDbDataAdapter m_Adapter;
            DataTable dTable;
        }
    }
