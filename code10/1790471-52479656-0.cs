        public List<ChainAuthorizations> GetAuthListByChain(string chainId)
        {
            List<ChainAuthorizations> cAuths = new List<ChainAuthorizations>();
            SqlConnection con = new SqlConnection("connection string data here");
            SqlDataAdapter sda = new SqlDataAdapter("usp_GetAuthorizedItemDetails",
            con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add(new SqlParameter("@chainId",
            SqlDbType.VarChar));
            sda.SelectCommand.Parameters["@chainId"].Value = chainId;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cAuths = (from DataRow dr in dt.Rows
                           select new ChainAuthorizations()
                           {
                               //Change with your model
                               StudentId = Convert.ToInt32(dr["StudentId"]),
                               StudentName = dr["StudentName"].ToString(),
                               Address = dr["Address"].ToString(),
                               MobileNo = dr["MobileNo"].ToString()
                           }).ToList();
            return cAuths;
        }
