    using (IDisposable cmd = new SqlCommand(), con = (cmd as SqlCommand).Connection)
    {
       var command = (cmd as SqlCommand);
       var connection = (con as SqlConnection);
       //code
    }
