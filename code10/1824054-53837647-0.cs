    using (SqlDataReader reader2 = myCommand2.ExecuteReader()) {
        if (reader2.Read()) {
            saldoLbl.Text = reader2.GetInt32(0).ToString();
        }
    }
