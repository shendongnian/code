    private DataSet FilterData()
        {
            DataSet filteredData = new DataSet("FilteredData");
            DataView viewAccount = new DataView(global65DataSet.SET_ACCOUNT_TABLE);
            viewAccount.Sort = "Number ASC";
            viewAccount.RowFilter = " Number >= '" + beginningAcct+"' AND Number <= '" + endAcct + "' ";
            DataView viewTrans = new DataView(global65DataSet.SET_TRANSACTION_TABLE);
            viewTrans.Sort = "Transaction_ID ASC, DateTime ASC";
            viewTrans.RowFilter = " DateTime >= '" + beginningDate.ToShortDateString() + "' AND DateTime <= '" +
                                  endDate.ToShortDateString() + "'";
            filteredData.Tables.Add(viewAccount.ToTable());
            filteredData.Tables.Add(viewTrans.ToTable());
            filteredData.Tables[0].TableName = "SET_ACCOUNT_TABLE";
            filteredData.Tables[1].TableName = "SET_TRANSACTION_TABLE";
            
            return filteredData;
        }
