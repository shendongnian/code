    public List<Courses> GetByEducation()
    {
        List<Courses> education = new List<Courses>();
        SqlConnection conn = new SqlConnection(my conn);
        try
        {
            conn.Open();
            string query = "SELECT education FROM Courses ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               education= dr.GetString(1);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return education;
    }
