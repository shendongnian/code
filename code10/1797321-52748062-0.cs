        public class Club
        {
            public string ClubName { get; set; }
            public string ClubEmail { get; set; }
            public string ClubPassword { get; set; }
        }
        [WebMethod]
        public static List<Club> ClubInfo(string id)
        {
            SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();
            List<Club> clb = new List<Club>();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[tb_ClubDetails] where ClubID = @ClubID", con);
            cmd.Parameters.AddWithValue("@ClubID", id);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                clb.Add(new Club
                {
                    //ClubID = Convert.ToInt32(rdr["ClubID"]),
                    ClubName = rdr["ClubName"].ToString(),
                    ClubEmail = rdr["ClubEmail"].ToString(),
                    ClubPassword = rdr["ClubPassword"].ToString(),
                });
            }
            con.Close();
            return clb;
        }
