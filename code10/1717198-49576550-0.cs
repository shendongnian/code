    public void StartSession(int port)
    {
        Form1 form1 = new Form1();
        while (true)
        {
            try
            {
                // ...
                form1.GetData(ClientAdress, update);
                // Tell the application to execute other events that are in queue
                Application.DoEvents();
                // ...
            }
            catch (Exception ex)
            {
                form1.Exception(ex);
            }
        }
    }
