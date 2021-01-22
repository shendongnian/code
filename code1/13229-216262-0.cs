    public static int AddMessage(string callID, string content)
        {
            Int32 newProdID = 0
            string select =
                "INSERT INTO Sporocilo (oznaka_klica, smer, vsebina, prebrano, cas_zapisa) VALUES (@callId, 0, @content, 0, @insertTime)";
            SqlCommand cmd = new SqlCommand(select, conn);
            cmd.Parameters.AddWithValue("callId", callID.ToString());
            cmd.Parameters.AddWithValue("content", content);
            cmd.Parameters.AddWithValue("insertTime", "10.10.2008");
            try
            {
                conn.Open();
                newProdID = (Int32)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                string sDummy = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return (int)newProdID
        }
