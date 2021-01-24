    using (SqlConnection conn = new SqlConnection(@"server=.\DOKUSTAR;Database=RdaDB10;Trusted_Connection=Yes"))
    using (SqlCommand comm = new SqlCommand(@"select top(1) clasedocField, operacionField
    from Clase_Documento
    where codafipField = @codafip", conn))
    {
     comm.Parameters.Add("@codafip", SqlDbType.VarChar).Value = codafip.Value;
     conn.Open();
    
      SqlDataReader dr = comm.ExecuteReader();
      if(dr.Read())
      {
            clasedoc.Value = (string)dr["claseDocField"];
            operacion.Value = (string)dr["operacionField"];
      }
    }
