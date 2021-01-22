     public Form1()
        {
            /****************************************************************/
            string sqlSchema = "  SELECT TABLE_CATALOG AS tblname ";
            sqlSchema += " , TABLE_SCHEMA AS tblschema  ";
            sqlSchema += " , TABLE_NAME AS tblname  ";
            sqlSchema += " , COLUMN_NAME AS colname  ";
            sqlSchema += " , DATA_TYPE AS DATA_TYPE  ";
            sqlSchema += " , CHARACTER_MAXIMUM_LENGTH AS colsize  ";
            sqlSchema += " FROM INFORMATION_SCHEMA.COLUMNS  ";
    
    
            InitializeComponent();
            OleDbConnection cn = new OleDbConnection(@"Provider=SQLNCLI;Server=THINK\SQLExpress;Database=Northwind;Trusted_Connection=yes;");
             Form1DataAdapter = new OleDbDataAdapter(sqlSchema, cn);
            DataTable dt = new DataTable();
    
            da.TableMappings.Add("Table","Schema");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void sql_PopulateTable(string tablenm, int rows)
        {
            // error on this line:
            DataTable table1 = Form1DataAdapter.Tables["Schema"];
    
    
        }
    
        public OleDbDataAdapter Form1DataAdapter { get; set; }
