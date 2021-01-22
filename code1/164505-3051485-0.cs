    YourDataContext ctx = new YourDataContext();
    SqlConnection con = (cufe.Connection as SqlConnection);
    if(con != null)
    {  
        con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage);
    }
