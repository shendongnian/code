            private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataSet.Relations.Clear();
            dataSet.Tables["Table2"].Clear();
            dataSet.Tables["Table1"].Clear();
            Table1 = ord.Get_Orders();
            Table2 = ord.Get_Order_Res();
            dataSet.Tables.Add(Table1);
            dataSet.Tables.Add(Table2);
            dataSet.Relations.Add("OrderDetails",
            dataSet.Tables[(Table1.TableName)].Columns["Bon N"],
            dataSet.Tables[(Table2.TableName)].Columns["Bon N"]);
            gridControl3.DataSource = dataSet.Tables[(Table1.TableName)];
            gridControl3.ForceInitialize();
        }
