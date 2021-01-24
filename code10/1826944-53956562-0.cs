    public Form1()
            {
                InitializeComponent();
                BindColumnnameToComboBox();
            }
            public void BindColumnnameToComboBox()   
            {
                DataRow dr;
    
    
                SqlConnection con = new SqlConnection(@"Data Source=NiluNilesh;Initial Catalog=mynewdata;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS i where i.TABLE_NAME = 'Mark'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
    
                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "--Select--" };
                dt.Rows.InsertAt(dr, 0);
               
                comboBox1.ValueMember = "COLUMN_NAME";
            
                comboBox1.DisplayMember = "COLUMN_NAME";
                comboBox1.DataSource = dt;
                
                con.Close();
    
    
            }
 
