            try
            {
                if (ds.Tables[0].Columns.Count == ds1.Tables[0].Columns.Count)
                {
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                       {
           if (ds.Tables[0].Rows[i][j].ToString() == ds1.Tables[0].Rows[i][j].ToString())
                           {
                               
                            }
                            else
                            {
                              
                               MessageBox.Show(i.ToString() + "," + j.ToString());
                           }
                                                   }
                    }
                }
                else
                {
                   MessageBox.Show("Table has different columns ");
                }
            }
            catch (Exception)
            {
               MessageBox.Show("Please select The Table");
            }
