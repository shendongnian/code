    public static List<int> Lista(int id,string paramName)
    {
        List<int> list = new List<int>();
        using (FbConnection con = new FbConnection(M.Baza.connectionKomercijalno2018))
        {
            con.Open();
            using (FbCommand cmd = new FbCommand("SELECT BRDOK FROM DOKUMENT WHERE MAGACINID = @MID ORDER BY DATUM ASC", con))
            {
                cmd.Parameters.AddWithValue(paramName, id);
    
                FbDataReader dr = cmd.ExecuteReader();
    
                while (dr.Read())
                {
                    list.Add(Convert.ToInt32(dr[0]));
                }
            }
        }
        return list;
    }
