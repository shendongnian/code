using (DbConnection connection = new SqlConnection("Your connection string")) {
    connection.Open();
    using (DbCommand command = new SqlCommand("alter table [Product] add [ProductId] int default 0 NOT NULL")) {
        command.Connection = connection;
        command.ExecuteNonQuery();
    }
}
