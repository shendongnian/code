     Outlook.Application app;
                try
                {
                    app = (Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
                }
                catch
                {
                    app = new Outlook.Application();
                }
    
                if (app == null)
                {
                    return;
                }
