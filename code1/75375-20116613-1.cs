           //table kuuku with column kuku(nvarchar2(100))
            string connString = "your connection";
 
            //CLEAN TABLE
            using (System.Data.OracleClient.OracleConnection cn = new System.Data.OracleClient.OracleConnection(connString))
            {
                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand("delete from  kuku ", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
 
 
            //INSERT WITH PARAMETER BINDING - UNICODE SAVED
            using (System.Data.OracleClient.OracleConnection cn = new System.Data.OracleClient.OracleConnection(connString))
            {
                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand("insert into  kuku (kuku) values(:UnicodeString)", cn);
                cmd.Parameters.Add(":UnicodeString", System.Data.OracleClient.OracleType.NVarChar).Value = input + " OK" ;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
 
            //INSERT WITHOUT PARAMETER BINDING - UNICODE NOT SAVED
            using (System.Data.OracleClient.OracleConnection cn = new System.Data.OracleClient.OracleConnection(connString))
            {
                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand("insert into  kuku (kuku) values('" +input+" WRONG')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //FETCH RESULT
            using (System.Data.OracleClient.OracleConnection cn = new System.Data.OracleClient.OracleConnection(connString))
            {
                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand("select kuku from kuku", cn);
                System.Data.OracleClient.OracleDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    string output = (string) dr[0];
                    char sa = output[0];
                }
                cn.Close();
            }
        }
