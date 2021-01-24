    private void button1_Click_1(object sender, EventArgs e)
    {
         var result = GetData();
         // do whatever with your data
    }
    private IList<ResultObject> GetData()
    {
        IList<ResultObject> result = new List<ResultObject>();
        
        string strconc = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\\Program Files\\TPMicroVix\\reg_tp.accdb;";
        using (OleDbConnection objConnect = new OleDbConnection(strconc))
        using (OleDbCommand Cmm = new OleDbCommand())
        {
            objConnect.Open();
            Cmm.CommandText = "SELECT cnpj, nome_cl, portal, empresa, email, tel, canal, detalhes FROM reg_tp WHERE n_tp = ?;";
            Cmm.CommandType = CommandType.Text;
            Cmm.Connection = objConnect;
            using (OleDbDataReader DR = Cmm.ExecuteReader())
            {
                  ResultObject obj = new ResultObject
                  {
                       Prop1 = DR.GetString("cnpj"),
                       Prop2 = DR.GetString("nome_cl"),
                       ....
                  }
                  result.Add(obj);
            }
        }
        return result;
    }
