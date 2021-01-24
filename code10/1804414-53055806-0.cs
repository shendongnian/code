    public partial class Form1 : Form
            {
    	    System.Data.DataSet DtSet = new System.Data.DataSet();
    
                public Form1()
                {
                    InitializeComponent();
                }
    
                private void Form1_Load(object sender, EventArgs e)
                {
                    // TODO: This line of code loads data into the 'database.Stocks' table. You can move, or remove it, as needed.
    
                    // this.stocksTableAdapter.Fill(this.database.Stocks);
    		           LoadData();
    
                }
    
    	private void LoadData()
    	{
     		try {
                	System.Data.OleDb.OleDbConnection MyConnection;
                	// System.Data.DataSet DtSet;
                	System.Data.OleDb.OleDbDataAdapter MyCommand;
                	MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textselect.Text + "; Extended Properties = Excel 8.0");
                	MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + textchoice.Text + "$]", MyConnection);
                	MyCommand.TableMappings.Add("Table", "TestTable");
                	// DtSet = new System.Data.DataSet();
                	MyCommand.Fill(DtSet);
                	dataGridView.DataSource = DtSet.Tables[0];
                	MyConnection.Close();
    
            	}
            	catch (Exception ex)
            	{
               	 MessageBox.Show(ex.ToString());
            	}
    	}       
    
                private void btnLoad_Click(object sender, EventArgs e)
                {
                    // rest of the function stays same, only change the line shown below
                    // chart.DataSource = database.Stocks;
    		chart.DataSource = DtSet.Tables[0];
    
                }
