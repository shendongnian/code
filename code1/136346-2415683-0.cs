    public void AutoCompleteTextBox(string tableName, string fieldName, TextBox txtToAutoComp)
            {
                AutoCompleteStringCollection txtCollection = new AutoCompleteStringCollection();
                DataTable dtAutoComp = Dal.ExecuteDataSetBySelect("Stored_Procedure", fieldName, tableName);
                if (dtAutoComp.Rows.Count >= 0)
                {
                    for (int count = 0; count < dtAutoComp.Rows.Count; count++)
                    {
                        txtCollection.Add(dtAutoComp.Rows[count][fieldName].ToString());
                    }
                }
                txtToAutoComp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtToAutoComp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtToAutoComp.AutoCompleteCustomSource = txtCollection;
            }
