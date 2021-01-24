    using(SqlCommand cmd = new SqlCommand("Sp_Ledger_PartyLedgerReport", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        // use EXPLICIT types here that match your database columns. Trust me.
        cmd.Parameters.Add("@ProfileId", SqlDbType.Int).Value = profileID;
        cmd.Parameters.Add("@PartyId", SqlDbType.Int).Value = partyID;
        cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
        cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
    
        //if you're just gonna convert to a List right away, DataAdapter/DataTable have extra overhead
        con.Open();
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                //reduce boilerplate & indentation with DataReader and type initializer
                var l = new Ledger() {
                    LedgerNo = (string)rdr["Ledger_No"],
                    ProfileFullName = (string)rdr["Profile_FullName"],
                    ProfileAddress = (string)rdr["Profile_Address"],
                    ProfileContact = (string)rdr["Profile_Contact"],
                    CustomerId = (int)rdr["Party_Id"],
                    CustomerName = (string)rdr["Party_Name"],
                    LedgerType = (string)rdr["Ledger_Type"],
                    //Do you *really* need ToString() and Parse() calls here?
                    //they have surprisingly high performance costs, and 
                    // you get by just fine without them on other columns.
                    LedgerDate = DateTime.Parse(rdr["Ledger_Date"].ToString()), 
                    Remarks = (string)rdr["Remarks"],
                    OpeningBalance = (int)rdr["OpeningBalance"],
                    TotalCredit = (int)rdr["Credit"],
                    TotalDebit = (int)rdr["Debit"], 
                };
                int cb = (int)rdr["ClosingBalance"];
                l.Balance = (cb == 0) ? 
                   l.OpeningBalance - l.TotalCredit + l.TotalDebit : 
                   cb - l.TotalCredit + l.TotalDebit;
    
                myList.Add(l);
            }
        }
    }
