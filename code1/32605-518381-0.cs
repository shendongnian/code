private static void Main(string[] args)
{
    SqlConnection conn = new SqlConnection("...");
    try
    {
        conn.Open();
        DoStuff();
    }
    finally
    {
        if (conn != null)
        {
            conn.Dispose();
        }
    }
}
