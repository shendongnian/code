      private void btnreadExcell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string filePath = string.Empty;
                string fileExt = string.Empty;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                Nullable<bool> result = ofd.ShowDialog();
                if (result == true)//if there is a file choosen by the user
                {
                    filePath = ofd.FileName;//get the path of the file
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                                                               // dataGrid.Visible = true;
                        dataGrid.ItemsSource = dtExcel.DefaultView;
                        datagridheader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                con.Close();
            }
            catch { MessageBox.Show("error");}
        }
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            DataTable dtexcel = new DataTable();
            try
            {
                string conn = string.Empty;
              
                if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                    conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
                else
                    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    try
                    {
                        OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                        oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                conn.Clone();
            }
            catch { MessageBox.Show("error"); }
            return dtexcel;
        }
