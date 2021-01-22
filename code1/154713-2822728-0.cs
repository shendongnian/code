    {
        DataTable properties = new DataTable();
        try
        {
            //do something
            return properties;
        }
        finally
        {
            if(properties != null)
            {
                ((IDisposable)properties).Dispose();
            }
        }
    }
