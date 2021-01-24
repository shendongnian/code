    public static void DoWork()
    {
    
    //put all your code in here, and you then you can pause it without  it freezing
    
    }
    
    public static void StartWorker()
    {
        Thread worker = new Thread(DoWork);
        worker.IsBackground = true;
        worker.SetApartmentState(System.Threading.ApartmentState.STA);
        worker.Start()
    }
