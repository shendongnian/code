    static void Main(string[] args)
    {
        ServiceManager.RegisterService<SessionService>();
    
        Session session;
        if(ServiceManager.GetService<SessionService>().CreateSession(out session) == CreateSessionResult.Success)
        {
            MainWindow window = new MainWindow();
            window.SetSession(session);
            Application.Run(window);
        }
        ServiceManager.UnregisterService<SessionService>();
    }
