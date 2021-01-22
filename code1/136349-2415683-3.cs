    public void AutoCompleteTextBox(string tableName, string fieldName, ComboBox combToAutoComp)
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
                combToAutoComp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combToAutoComp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                combToAutoComp.AutoCompleteCustomSource = txtCollection;
            }
