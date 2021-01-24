     public partial class Form1 : Form                  
        {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        SqlDataAdapter sda2;
        SqlCommandBuilder scb2;
        DataTable dt2;
        public Form1()
        {
            InitializeComponent();
        }
    //ON FORM LOAD
     private void Form1_Load(object sender, EventArgs e)
            {
                String stringConnection = @"Data Source=SERVER_NAME;    Initial Catalog =DB_NAME; User ID =USER; Password =PASS;";
                SqlConnection con2 = new SqlConnection(stringConnection);
                try
                {
                con2.Open();
                SqlCommand sqlCmd2 = new SqlCommand();
                sqlCmd2.Connection = con2;
                sqlCmd2.CommandType = CommandType.Text;
                sqlCmd2.CommandText = "SELECT name FROM sys.databases EXCEPT SELECT name FROM sys.databases WHERE name='master' OR name='model' OR name='msdb' OR name='tempdb'";
                SqlDataAdapter sqlDataAdap2 = new SqlDataAdapter(sqlCmd2);
                DataTable dtRecord2 = new DataTable();
                sqlDataAdap2.Fill(dtRecord2);
                dtRecord2.DefaultView.Sort = "name ASC";
                comboBox2.DataSource = dtRecord2;
                comboBox2.DisplayMember = "NAME";
                comboBox2.DisplayMember = "NAME";
                con2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    //BUTTON FOR SHOWING TABELS IN DATAGRIDVIEW
    private void ShowTbl_Click(object sender, EventArgs e)
        {
            string selected = this.ComboBox1.GetItemText(this.ComboBox1.SelectedItem);
            string DBselected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            SqlConnection con = new SqlConnection(@"Data Source=SERVER_NAME;Initial Catalog =" + DBselected + "; User ID=USER;Password=PASS;");
            sda = new SqlDataAdapter(@"SELECT *  FROM dbo.[" + selected + "]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            string ComboBoxSelected = ComboBox1.GetItemText(ComboBox1.SelectedItem);
            con.Close();
        }
    //WHEN I SELECT DATABASE IN COMBOBOX2, COMBOBOX1 DISPLAYS TABLES IN THAT DATABASE
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedbase = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            string aa = comboBox2.SelectedText;
            String strConnection = @"Data Source=SERVER_NAME;Initial Catalog =" + selectedbase+ "; User ID =USER; Password =PASS;";
            SqlConnection con = new SqlConnection(strConnection);
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select table_name from information_schema.tables";
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                dtRecord.DefaultView.Sort = "table_name ASC";
                ComboBox1.DataSource = dtRecord;
                ComboBox1.DisplayMember = "TABLE_NAME";
                ComboBox1.DisplayMember = "TABLE_NAME";
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
