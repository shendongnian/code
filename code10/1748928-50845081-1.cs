    Using(SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JO0MC7T\\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True;User ID=****;Password=***"))
    {
        conn.Open();
        SqlCommand command = new SqlCommand("Select nombre from Prueba where Id=@zip", conn);
        command.Parameters.AddWithValue("@zip", txtdataBase.Text);
        SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string myresult = reader.GetString(0);// what ever datatype
                lbResultado.Text = myresult; 
            }
        }
    }
