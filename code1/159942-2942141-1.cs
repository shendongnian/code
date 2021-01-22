    try {
        SqlConnection cn = new SqlConnection(connectionString);
    
        // whatever other code
    }
    finally {
        if (cn != null)
        {
            cn.Dispose();
        }
    }
