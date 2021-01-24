private void loginbtn_Click(object sender, EventArgs e)
{
    var conString = "ReplaceWithMyConnectionString";
    string userRole = null;
    using (var con = new SqlConnection(conString))
    {
        con.Open();
        var cm = con.CreateCommand();
        cm.CommandType = System.Data.CommandType.Text;
        cm.CommandText = "SELECT TOP 1 Role FROM User_Table WHERE eb_number = @eb_number AND and Password = @Password";
        cm.Parameters.Add(new SqlParameter("@eb_number", System.Data.SqlDbType.VarChar, 50) { Value = usernametxt.Text });
        cm.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50) { Value = textBox1.Text });
        using (var reader = cm.ExecuteReader(System.Data.CommandBehavior.SingleRow))
        {
            if (reader.Read())
            {
                userRole = reader["Role"].ToString();
            }
        }
    }
    if (userRole != null)
    {
        this.Hide();
        Main ss = new Main(usernametxt.Text, userRole); //usernametxt is passed in to prevent error
        ss.Show();
        MessageBox.Show("Logged in sucessfully");
    }
    else
    {
        MessageBox.Show("Incorrect Username/Password Combination. Try Again");
    }
}
There are a few things that are different, I'll explain the reason behind them:
 - I replaced with parameters the string concatenation you were doing on your SQL. This is to avoid SQL injection. Have you wondered
   what would happen if the user enters the character `'` in the
   username or password textboxes? there's more to this, please research this subject.
 - I'm instantiating your connection inside a `using` statement. This will make sure that your connection is closed (disposed) when we are done with the db stuff.
 - Replaced the DataAdapter/DataTable with a leaner SqlCommand/SqlDataReader classes.
 - I separated the logic in a way that the connection can be closed asap, and is not being interrupted by the call to MessageBox.Show().
Also, and very important, never store your passwords as clear text in the database, please do some research about hashing functions and why they should be used in this context.
I hope this helps.
