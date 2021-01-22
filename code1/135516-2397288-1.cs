    // Note that you have to add the params argument, 
    // which isn't usually present in windows services
    private static void Main(params string[] parameters)
    {
        ....
        if (parameters.Length > 0)
        {
            if (parameters[0].ToLower() == "/console")
            {
                Application.Run(new ServiceControllerForm(service));  
            {
            else
            {
                ServiceBase.Run(windowsService);
            }
        }
    }
