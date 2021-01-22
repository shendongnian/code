      DataSet1 ds = new DataSet1();
                var da = new DataSet1TableAdapters.DepositTableAdapter();
                var da1 = new DataSet1TableAdapters.Deposit_1TableAdapter();
                da.Fill(ds.Deposit);
                
                foreach (DataSet1.DepositRow row in ds.Deposit.Rows)
                {
                    if (row.ID == 3)
                    {
                        row.Amount++;
                    }
                    foreach (var c in row.ItemArray)
                    {
                        Console.Write(c);
                        
                    }
                    Console.WriteLine("");
                }
    
                Console.WriteLine(ds.Deposit.GetChanges(System.Data.DataRowState.Modified).Rows);
    
    
                var updateTable = new DataSet1.Deposit_1DataTable();
    
                foreach (DataSet1.DepositRow row in ds.Deposit.GetChanges(System.Data.DataRowState.Modified).Rows)
                {
                    updateTable.ImportRow((System.Data.DataRow)row);
    
                }
                da1.Update(updateTable);
