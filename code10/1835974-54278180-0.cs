    try
    {
        conn.Open(); // Open the connection
        cmd.ExecuteNonQuery();
        MessageBox.Show("Successfully saved");
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        conn.Close(); // Close the connection
    }
