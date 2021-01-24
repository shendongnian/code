    public void Update()
    {
        using(SqlConnection con = new SqlConnection("SomeSqlString"))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("Update Manufacturers set Id = @id ....", con))
            {
                cmd.Parameters.AddWithValue("@id", m.Id);
                //Assigning other paramterts
                cmd.ExecuteNonQuery();
                //Display message of success
            }
        }
    }
