            DataTable a = new DataTable();
            a = ((DataView)ctrlgridviewdulieu0.ItemsSource).ToTable();
            foreach (DataRow row in a.Rows)
            {
                DataTable dtrow = new DataTable();
                dtrow = a.Clone();
                dtrow.ImportRow(row);
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(" SELECT * FROM viewdulieu2 WHERE Khachdat = N'" + dtrow.ToString() + "'", cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    XtraReport1 report = new XtraReport1();
                    report.DataSource = dt1;
                    //   report.Print();
                    cnn.Close();
                    report.ShowPreviewDialog();
                }
                catch (Exception ex)
                {
                    cnn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
