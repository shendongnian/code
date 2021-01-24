    try
     {
       using (MySqlConnection sqlCon = new MySqlConnection(conn))
         {
           using (MySqlCommand cmd = new MySqlCommand())
            {
              cmd.CommandText = "Insert into autorizaciones " +
              "(comprobante, Serie_Comprobante, Ruc_Emisor, RazonSoc_Emisor, " +
              "Fecha_Emision, Fecha_Autorizacion, " +
              "Tipo_Emision, Ident_Receptor, Clave_Acceso, Numero_Autorizacion) " + 
     "values(@comprob,@serComprob,@rucEmisor,@razSocEmi,@FecEmisor,@FecAutoriz,@tipoEmision,@identRecep,@claveAcceso,@numAutoriz)";
         cmd.Parameters.AddWithValue("@comprob", comprob);
         cmd.Parameters.AddWithValue("@serComprob", serComprob);
         cmd.Parameters.AddWithValue("@razSocEmi", razSocEmi);
         cmd.Parameters.AddWithValue("@FecEmisor", FecEmisor);
         cmd.Parameters.AddWithValue("@FecAutoriz", FecAutoriz);
         cmd.Parameters.AddWithValue("@tipoEmision", tipoEmision);
         cmd.Parameters.AddWithValue("@identRecep", DateTime.Parse(identRecep,"MM/DD/YYYY"));
         cmd.Parameters.AddWithValue("@claveAcceso", claveAcceso);
         cmd.Parameters.AddWithValue("@numAutoriz", numAutoriz);
         cmd.Connection = sqlCon;
         sqlCon.Open();
         cmd.ExecuteNonQuery();
         sqlCon.Close();
      }
     }
    }
    catch (MySqlException ex)
        {
        }
  
