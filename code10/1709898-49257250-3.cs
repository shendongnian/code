    private void MyTimerMethode()
    {
        while (true)
        {
            // do stuff...
            Thread.Sleep(5000); //wait 5 seconds
        }
    }
        Thread timer = new Thread(MyTimerMethode);
        timer.SetApartmentState(ApartmentState.STA); //creates a new Thread for UIs
        timer.IsBackground = true;
        timer.Start();
