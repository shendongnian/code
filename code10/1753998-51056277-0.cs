    .
    .
    .
    cmd.Connection = conn;
    try
        {
           conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                  .
                  .
                  .
        else
                {
                    MessageBox.Show("Connection Failed");
                }
        catch (Exception ex)
    {
    MessageBox.Show(ex.toString());
    conn.Close();
    }
