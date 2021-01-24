    public DataTable Liste()
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JHLF03K\\SQLEXPRESS;Initial Catalog=OtelWebSite;Integrated Security=True");
        string sql = "";
        sql += "SELECT ";
        sql += "O.Id, ";
        sql += "O.OdaTurId,";
        sql += "T.Ad AS OdaTur, ";
        sql += "O.Ad, ";
        sql += "O.KatNo, ";
        sql += "O.Aciklama, ";
        sql += "K.Tanim AS Durum ";
        sql += "FROM Oda O, Kod K,OdaTur T  ";
        sql += "WHERE O.Durum = K.Kod ";
        sql += "AND T.Id = O.OdaTurId ";
        sql += "ORDER BY O.Id,O.OdaTurId";
        SqlDataAdapter dap = new SqlDataAdapter(sql, con);  
        DataTable table = new DataTable();
        con.Open();
        dap.Fill(table);
        con.Close();
        return table;
    }
