    private void OpenForm()
    {
        if (FormThread == null)
        {
            object obj = new object();
            lock (obj)
            {
                FormThread = new Thread(delegate () {
                    lock (obj)
                    {
                        Form = new ControllerForm();
                        Monitor.Pulse(obj);
                    }
                    Application.Run(Form);
                });
                FormThread.SetApartmentState(ApartmentState.STA);
                FormThread.Start();
                Monitor.Wait(obj);
            }
        }
    }
