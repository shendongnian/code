    public CarasViewModel()
    {
     AddCommand = new ICommand<Task>(() => Add());
    }
    public ICommand AddCommand { get; private set; }
    async Task Add()
    {
       Thread longRunningThread = new Thread(new ThreadStart(delegate (){ Thread.Sleep(10000); Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new CalculateTimeElapsed(OnAdd)); }));
    longRunningThread.Start();}
    void OnAdd{}
