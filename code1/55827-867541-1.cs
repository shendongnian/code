    public void MyMethod(string connStr)
    {
        try
        {
            DataClasses1DataContext dc = new DataClasses1DataContext(connStr);
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    //Do Stuff
                    //Insert Objects
                    dc.SubmitChanges();
                }
                catch (Exception ex) //So if it bombs in the loop, log your exception
                {
                    Log(ex);
                }
                finally //Reinstantiate your DC
                {
                    dc = new DataClasses1DataContext(connStr);
                }
            }
        }
        catch (Exception bigEx)
        {
            Log(bigEx);
        }
    }
