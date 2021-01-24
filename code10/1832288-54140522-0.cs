       public DataTable CombineofAdjustmentNTransaction(DataTable A, DataTable B)
        {
            DataTable TableE = new DataTable();
            TableE.Columns.Add(new DataColumn("Location"));
            TableE.Columns.Add(new DataColumn("Item Type"));
            TableE.Columns.Add(new DataColumn("AmountA"));
            TableE.Columns.Add(new DataColumn("AmountB"));
            TableE.Columns.Add(new DataColumn("Type"));
            foreach (DataRow dtE in A.Rows)
            {
                foreach (DataRow rowB in B.Rows)
                {
                    if (rowB["Location"].ToString() == dtE["Location"].ToString() && rowB["Item Type"].ToString() == dtE["Item Type"].ToString()
                        )
                    {
                        var newRow = TableE.NewRow();
                        newRow["Location"] = dtE["Location"];
                        newRow["Item Type"] = dtE["Item Type"];
                        if (dtE["Type"].ToString() == "GRN")
                        {
                            newRow["AmountA"] = dtE["AmountA"];
                            newRow["Type"] = "A";
                        }
                        if (rowB["Type"].ToString() == "STK_ADJ" && newRow["AmountA"].ToString() != "" && newRow["AmountA"].ToString() != "")
                        {
                            var BNewRow = TableE.NewRow();
                            BNewRow["Location"] = rowB["Location"];
                            BNewRow["Item Type"] = rowB["Item Type"];
                            BNewRow["AmountB"] = rowB["AmountB"];
                            BNewRow["Type"] = "B";
                            TableE.Rows.Add(BNewRow);
                        }
                        else {
                            newRow["AmountB"] = rowB["AmountB"];
                            newRow["Type"] = "B";
                        }
                        TableE.Rows.Add(newRow);
                    }
                }
            }
            return TableE;
        }
