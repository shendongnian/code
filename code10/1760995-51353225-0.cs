    private void button19_Click_1(object sender, EventArgs e)
        {
            DBStatus dbstst = new DBStatus();
    
            dbstst.Message = new List<DBMessageType>();
            dbstst.Message.Add(DBMessageType.INVALID_OR_EXPIRED_FUNCTION_REQUEST);
    
            dbstst.InnerException = new List<string>();
            dbstst.InnerException.Add("testing code");
    
            int k = 0;
        }
