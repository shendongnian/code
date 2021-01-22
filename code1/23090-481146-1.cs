    public static void DoWork()
    {
        // do some work
    }
    
    public static void StartWorker()
    {
        Thread worker = new Thread(DoWork);
        worker.IsBackground = true;
        worker.SetApartmentState(System.Threading.ApartmentState.STA);
        worker.Start()
    }
