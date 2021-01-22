    namespace enable
    {    
        public partial class Form1 : Form
        {
    
    	OleDbDataAdapter adapter;
    	DataTable dTable = new DataTable();
    
            public Form1()
            {
                InitializeComponent();
                OleDbConnection favouriteConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\192.168.123.5\\Share\\Matt\\BugTypes.mdb");
                string strSQL = "SELECT CategoryName, Show " + "FROM [Categories] WHERE Show = 'Yes' " + "ORDER BY CategoryName";
                adapter = new OleDbDataAdapter(strSQL, favouriteConnection);
                OleDbCommandBuilder cBuilder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dTable;
                dataGridView1.DataSource = bSource;
                adapter.Update(dTable);            
            }
            private void button1_Click(object sender, EventArgs e)
            {
                adapter.Update(dTable);//this is the button that needs to do the save, but can't see the variables.
            }
        }
    }
