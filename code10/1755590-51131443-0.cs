    query6 = "SELECT DISTINCT Weight_Box FROM MO_spec WHERE PC = @pc";
    using(SqlCommand cmd6 = new SqlCommand(query6, con5)))
    {
        cmd6.Parameters.Add("@pc", SqlDbType.VarChar).Value = textBox1.Text;
        using(SqlDataReader dr1 = cmd6.ExecuteReader())
        {
             ......
        }
    }
