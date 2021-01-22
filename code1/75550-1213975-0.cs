    void Run()
    {
        using( MyDialog dialog = new MyDialog() )
        {
            Application.AddMessageFilter(new MyMessageFilter());
            Application.Run(dialog); 
        }
    }
