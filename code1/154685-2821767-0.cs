    SqlConnection c ...
    c.InfoMessage += new SqlInfoMessageEventHandler(cb_Msg);
...
    
    void cb_Msg(object sender, SqlInfoMessageEventArgs e)
    {
        // e.Message has a line of PRINT output
    }
