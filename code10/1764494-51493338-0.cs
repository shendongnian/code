     var dat = new DataSet("Set1");
                var tab = new DataTable("Tab1");
                tab.Columns.Add(new DataColumn("Col1", typeof(int)));
                dat.Tables.Add(tab);
                tab.Rows.Add(123);
                var changes = dat.GetChanges();
                dat.Merge(changes);
                dat.AcceptChanges();
    
                Console.WriteLine("Row status is: {0}", tab.Rows[0].RowState); // Unchanged
                                                                               // Setting the same value will flag the Row "modified"
                tab.Rows[0]["Col1"] = tab.Rows[0]["Col1"];
                tab.Rows[0].AcceptChanges();
                if (dat.HasChanges()) // Actual Value: True, Expected Value: False
                {
                    Console.WriteLine("Row status is: {0}", tab.Rows[0].RowState); // Actual Value: Modified, Expected Value: Unchanged
                }
