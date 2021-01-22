    private int chek1(String insert)
            {
    
                OleDbConnection con = null;
                try {
                con = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=d:\\sdb.mdb");
                OleDbCommand com = new OleDbCommand("select count(*) from sn where sn='" + insert + "\'", con);           
                con.Open();
    
                int po = (int)com.ExecuteScalar();           
                if (po > 0)
                    return 1;
                else
                    return 0;
                }
                finally {
                    con.Close();
                }
    
            }
