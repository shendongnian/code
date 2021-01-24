      private void btnRefresh_Click(object sender, EventArgs e)
                {
                   gridControl3.DataSource=null;
            gridControl3.Items.Clear();
                    Table1 = ord.Get_Orders();
                    Table2 = ord.Get_Order_Res();
                    dataSet.Tables.Add(Table1);
                    dataSet.Tables.Add(Table2);
            
            
                    gridControl3.DataSource = dataSet.Tables["Table1"];
                    gridControl3.ForceInitialize();
            
            }
