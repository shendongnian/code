    namespace FrequencyBook
    {
    public partial class Form11 : Form
    {
        private static Form11 alreadyOpened = null;
        public Form11()
        {
            InitializeComponent();
            {
                if (alreadyOpened != null && !alreadyOpened.IsDisposed)
                {
                    alreadyOpened.Focus();            // Bring the old one to top
                    Shown += (s, e) => this.Close();  // and destroy the new one.
                    return;
                }
                // Otherwise store this one as reference
                alreadyOpened = this;
            }
        }
        private DataTable dt = new DataTable();
        private void Form11_Load(object sender, EventArgs e)
        {
            dataGridView11.DataSource = GetSearchForm();
        }
        
        private DataTable GetSearchForm()
        {
            string connString = ConfigurationManager.ConnectionStrings["FrequencyBook.Properties.Settings.db_FrequenciesConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand("Select * FROM tbl_Users", conn))
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            dt.Columns["ID"].ColumnName = "ID";
            dt.Columns["Licensee"].ColumnName = "Licensee";
            dt.Columns["Callsign"].ColumnName = "Callsign";
            dt.Columns["LocalNo"].ColumnName = "Unit";
            dt.Columns["Location"].ColumnName = "Location";
            dt.Columns["FreqBand"].ColumnName = "Band";
            dt.Columns["Email"].ColumnName = "Email";
            dt.Columns["Phone"].ColumnName = "Phone";
            dt.Columns["RID1"].ColumnName = "RID1";
            dt.Columns["RID2"].ColumnName = "RID2";
            dt.Columns["RID3"].ColumnName = "RID3";
            dt.Columns["RID4"].ColumnName = "RID4";
            dt.Columns["Notes"].ColumnName = "Notes";
            return dt;
        }
        private void closeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void resetFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tboxSearchLicensee.Clear();
            tboxSearchCallsign.Clear();
            tboxSearchLocation.Clear();
            tboxSearchBand.Clear();
            tboxSearchRID.Clear();
            tboxSearchLocalNo.Clear();
        }
        private void tboxSearchLicensee_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Licensee LIKE '%" + tboxSearchLicensee.Text + "%'" ;
        }
        private void tboxSearchCallsign_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Callsign LIKE '%" + tboxSearchCallsign.Text + "%'" ;
        }
        private void tboxSearchLocation_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Location LIKE '%" + tboxSearchLocation.Text + "%'" ;
        }
        private void tboxSearchBand_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Band LIKE '%" + tboxSearchBand.Text + "%'" ;
        }
        private void tboxSearchRID_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("RID1 LIKE '%{0}%' OR RID2 LIKE '%{0}%' OR RID3 LIKE '%{0}%' OR RID4 LIKE '%{0}%'", tboxSearchRID.Text);
            //DataView dv = dt.DefaultView;
            //dv.RowFilter = "RID1 LIKE '%" + tboxSearchRID.Text + "%'" ;
        }
        private void tboxSearchLocalNo_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Unit LIKE '%" + tboxSearchLocalNo.Text + "%'" ;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //This button has changed to btnReturnToUsers
            this.Hide();//Hide the 'current' form,  form11 
                        //show another form ( form12 )   
            Form12 frm = new Form12();
            frm.ShowDialog();
            //Close the form.(form11)
            this.Close();
        }
        private void btnReturnToMain_Click(object sender, EventArgs e)
        {
            this.Hide();//Hide the 'current' form,  form11 
                        //show another form ( form2 )   
            Form2 frm = new Form2();
            frm.ShowDialog();
            //Close the form.(form11)
            this.Close();
        }
    }
