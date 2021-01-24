     public void filldatagridview(ExcelWorksheet workSheet)
            {
                DataTable dt = new DataTable();
                DataTable dtInvtID = new DataTable();
                dt.Columns.Add("dtInvtID"); //ADDING NEW COLUMN FIRST FOR YOUR dtInvtID
                //Create the data column
                for (int col = workSheet.Dimension.Start.Column; col <= workSheet.Dimension.End.Column; col++)
                {
                    dt.Columns.Add(col.ToString());
                }
    
                for (int row = 12; row <= 26; row++)
                {
                    DataRow newRow = dt.NewRow(); //Create a row
                    int i = 0;
                    for (int col = workSheet.Dimension.Start.Column; col <= workSheet.Dimension.End.Column; col++)
                    {
                        newRow[i++] = workSheet.Cells[row, col].Text;
                    }
                    dt.Rows.Add(newRow);
                }
    
                dt.Columns.RemoveAt(0); //remove No
                dt.Columns.RemoveAt(0); //remove article
    
                //Get BookCode
                using (SqlConnection conn = new SqlConnection("Server"))
                using (SqlCommand cmd = new SqlCommand(null, conn))
                {
                    StringBuilder sb = new StringBuilder("WITH cte AS(SELECT case WHEN InvtID IS NULL OR InvtID='' THEN 'No Bookcode Found' ELSE InvtID END AS InvtID,Barcode,ROW_NUMBER() OVER(PARTITION BY Barcode ORDER BY InvtID Asc) rid FROM InventoryCustomer) SELECT InvtID AS BOOKCODE FROM cte WHERE rid=1 and Barcode In (");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i != 0) sb.Append(",");
                        string name = "@P" + i;
                        cmd.Parameters.AddWithValue(name, dt.Rows[i]["3"]); //"3" is barcode column
                        sb.Append(name);
                    }
                    sb.Append(")");
                    cmd.CommandText = sb.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtInvtID);
    
                    dt.Columns["BOOKCODE"].SetOrdinal(0);
                  
                }
    
    
                int dtctr = 0;
                int ctr = 0;
                foreach (DataRow dr in dt.Rows)//inserting the value of your InvtID to dt.Rows
                {
                    dtctr += 1;
                    ctr = 1;
                    foreach (DataRow InvtID in dtInvtID.Rows) //Getting the value of dtInvtID from database
                    {
                        if (ctr == dtctr)//Condition when the row position is equal (dt.Rows==dtInvtID.Rows) IF THIS NOT RETURN A REAL POSITION THEN YOU CAN RUN IT IN DEBUG MODE T CHECK
                        {
                            dr["dtInvtID"] = InvtID[0];
                            ctr += 1;
                            break;
                        }
                        ctr += 1;
                    }
                }
    
                dataGridView2.DataSource = dt;
            }
