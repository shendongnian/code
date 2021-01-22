    using(SqlConnection conn = new SqlConnection(@"Data Source=ASHISH-PC\SQLEXPRESS; initial catalog=bank; integrated security=true"))
    {
        conn.Open()
        using (SqlCommand command  = new SqlCommand("select total_amount from debit_account where account_no=12", conn)
        {
            var result = command.ExecuteScalar();
            Console.WriteLine("The total_amount for the account is {0}", result);
        }
    }
