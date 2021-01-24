    Thread timer = new Thread(() =>
    {
        while (true)
        {
            //do stuff...
            Thread.Sleep(5000); //wait 5 seconds
        }
     });
     timer.SetApartmentState(ApartmentState.STA); //creates a new Thread for UIs
     timer.IsBackground = true; //if you main Thread exits this will also shutdown.
     timer.Start();
