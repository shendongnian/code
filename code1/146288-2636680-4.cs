    public string ReadData()
    {
        string displayString = string.Empty;
        string query = "select max(LM_code) from Master_Accounts";
        // I'd look for something like ExecuteScalar
        string jid = Datamanager.RunExecuteScalar( Constr, query ).ToString();
        // You don't use the DataReader anymore, since you get your result from your Datamanager
        if (string.IsNullOrEmpty(jid))
        {
          jid = "AM0000";
        }
        int len = jid.Length;
        string split = jid.Substring(2, len - 2);
        int num = Convert.ToInt32(split);
        num++;
        return displayString = jid.Substring(0, 2) + num.ToString("0000");
     }
