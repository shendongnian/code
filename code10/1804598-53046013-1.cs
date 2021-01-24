    private void frmMain_Load(object sender, EventArgs e)
        {
            //Get Total Number of File to create Total Tab
            //Pass the count in the for loop
            //Store the File Path of Each File in List<string> lstFilePath
            
            for (int i = 0; i < 5; i++) //i< lstFilePath.Count
            {
                //Create Tab Programatically
                this.tabControl1.TabPages.Add("Tab Page"+ (i+1).ToString());                
                
                //Create DataTable to read and Store the CSV File Data
                DataTable Dt = new DataTable();
                
                //Based on the i value get the File Path from lstFilePath 
                //and pass it to Function below
                Dt = ConvertCSVtoDataTable("");               
                DataGridView grid = new DataGridView();
                this.tabControl1.TabPages[i].Controls.Add(grid);
                grid.DataSource = Dt;
            }
        }
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
