    // wrap IDisposable into using
    using (SqlConnection connect = new SqlConnection("connectionString"))
    {
        connect.Open();
        // Make SQL readable and parametrized
        string sql = 
          @"select Tanım 
              from TümEnvanter$ 
             where Ekipman = @prm_Ekipman";  
        // wrap IDisposable into using 
        using (SqlCommand cmdTanim = new SqlCommand(sql, connect))
        {   
            //TODO: explicit typing Add(..., dbType...) is a better choice then AddWithValue
            cmdTanim.Parameters.AddWithValue("@prm_Ekipman", comboBox_ekipman.Text);
            // We want one record only; ExecuteScalar() instead of ExecuteReader() 
            // String interpolation shortens the code
            labelTanim.Text = $"Ekipman Tanımı: {cmdTanim.ExecuteScalar()}";
        }
    }
