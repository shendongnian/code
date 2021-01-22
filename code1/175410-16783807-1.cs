    SqlConnection con = new SqlConnection(["ConnectionString"])
    SqlCommand com = new SqlCommand("EXEC _Proc @id",con);
    com.Parameters.AddWithValue("@id",["IDVALUE"]);
    con.Open();
    SqlDataReader rdr = com.ExecuteReader();
    ArrayList liste = new ArrayList();
    While(rdr.Read())
    {
        liste.Add(rdr[0]); // if it returns multiple you can add them another arrays=> liste1.Add(rdr[1]) ..
    }
    con.Close();
