    public double Get_Weight(int ID)
    {
        DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        DAL.Open();
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = ID;
        param[1] = new SqlParameter("@Weight", SqlDbType.Float);
        param[1].Value = DBNull.Value;
        param[1].Direction = ParameterDirection.Output;
        DAL.ExcuteCommande("Get_Weight", param);
        DAL.Close();
        
        double weight = 0.0;
        if(double.TryParse(param[1]?.Value?.ToString(), out weight)
        {
           return weight;
        }
        else
        {
            throw new ArgumentException("No Item found for given ID");
        }
    }
