    using (SqlLiteConnection conn = new SqlLiteConnection("put your connection string here")) {
        using (SqlLiteCommand cmd = new SqlLiteCommand("select Date from [ShopRegistration]", conn) {
            conn.Open();
            dateTimePicker.MinDate = DateTime.ParseExact((string)cmd.ExecuteScalar(),
                                                         "yy-MMM-dd",
                                                         CultureInfo.InvariantCulture).Date;
        }
    }
    dateTimePicker.MaxDate = DateTime.Now.Date;
