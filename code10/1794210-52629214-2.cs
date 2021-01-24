        using (SqlConnection conn = new SqlConnection(@"server=.\DOKUSTAR;Database=RdaDB10;Trusted_Connection=Yes"))
        using (SqlCommand comm = new SqlCommand(@"select top(1) clase, operacion
        from Clase_Documento
        where codigoafip = @codafip", conn))
        {
         comm.Parameters.Add("@codafip", SqlDbType.VarChar).Value = codafip
    ;
         conn.Open();
        
          SqlDataReader dr = comm.ExecuteReader();
          if(dr.Read())
          {
                clasedoc.Value = (string)dr["clase"];
                operacion.Value = (string)dr["operacion"];
          }
          else 
          {
               clasedoc.Value = "Not found";
          }
        }
