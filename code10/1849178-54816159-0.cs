     comboBox.Items.Clear(); // <-- Declare this at initialization of the page or whatever scenario you have
    
        private void Check1_CheckedChanged(object sender, EventArgs e)
        
            {
                if (Check1.CheckState == CheckState.Checked)
                {
                    // SQL Server connection
                    SqlConnection conn = new SqlConnection(@"Server = Server; Database = DB; Integrated Security = True");
                    DataSet ds = new DataSet();
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT [Column1] FROM [DB].[dbo].[Table1] WHERE [Column2] = 50", conn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        
    // Using loop to iterate the values and append the combo box
                        for(int i=0;i<da.Rows.Count;i++)
                       {
                             combo1.Items.Add(da[i]["Column1"].ToString());
                            combo1.Items[combo1.Itemx.Count-1].Text=da[i]["Column1"].ToString();
                            combo1.Items[combo1.Itemx.Count-1].Value=da[i]["Column1"].ToString();
                       }
        
        
        
                    }
                    catch (Exception ex)
                    {
                        //Exception Message
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
        
                if (Check1.CheckState == CheckState.Unchecked)
                {
                    combo1.DataSource = null;
                }
