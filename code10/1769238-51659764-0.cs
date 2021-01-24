    using (SqlLiteConnection conn = new SqlLiteConnection("put your connection string here")) {
        using (SqlLiteCommand cmd = new SqlLiteCommand("select Date from [ShopRegistration]", conn) {
            conn.Open();
            dateTimePicker.MinDate = DateTime.Parse((string)cmd.ExecuteScalar()).Date;
        }
    }
    dateTimePicker.MaxDate = DateTime.Now.Date;
