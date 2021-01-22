    try
    {
        var conn = new SqlConnection(TxtConnection.Text);
    }
    catch (Exception)
    {
        return false;
    }
    return true;
