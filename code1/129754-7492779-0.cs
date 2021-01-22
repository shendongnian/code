    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            // ...
        }
        catch (System.Configuration.ConfigurationErrorsException ex)
        {   
            var config = ((System.Configuration.ConfigurationErrorsException)ex.InnerException).Filename;
            // notify user, ask them to restart
            System.IO.File.Delete(config);
            Application.Exit();
        }
    }
