    string result = String.Empty;
    OracleConnection conn = new OracleConnection(connstr);
    OracleCommand cmd = new OracleCommand("PKG_AUCTION_ITEMS.IsAuctionItem",conn);
    myCmd.CommandType = CommandType.StoredProcedure;
    using (myCmd)
    {
        myCmd.Parameters.AddWithValue("vItemName", itemName);
        myCmd.Parameters.AddWithValue("vOpenDate", openDate);
        // depending on whether you're using Microsoft's or Oracle's ODP, you 
        // may need to use OracleType.Varchar instead of OracleDbType.Varchar2.
        // See http://forums.asp.net/t/1002097.aspx for more details.
        OracleParameter retval = new OracleParameter("ret",OracleDbType.Varchar2,2);
        retval.Direction = ParameterDirection.ReturnValue;
        myCmd.Parameters.Add(retval);
        myCmd.ExecuteNonQuery();
        result = myCmd.Parameters["ret"].Value.ToString();
    }
