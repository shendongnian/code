    // declare a background worker to init the API
    private BackgroundWorker _bgWorker;
    // ctor
    public HiPathScreenPop( ... )
    {
        ...
        
        _phoneListener = new ScreenPopTelephoneListener();
        _apiState = ApiState.Allocated;
        _phoneListener.StatusChanged += new _IScreenPopTelephoneListenerEvents_StatusChangedEventHandler( StatusChangedEvent );
        _phoneListener.ScreenPop += new _IScreenPopTelephoneListenerEvents_ScreenPopEventHandler( ScreenPopEvent );
        _bgWorker = new BackgroundWorker();
        _bgWorker.DoWork += new DoWorkEventHandler(StartInBackground);
        _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( bgWorker_RunWorkerCompleted );
        _bgWorker.RunWorkerAsync();
    }
     void _bgWorker_DoWork( object sender, DoWorkEventArgs e )
    {
        _phoneListener.Initialize( _strAddress );
    }
    void bgWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
    {
        _apiState = ApiState.Initialized;  // probably not necessary...
        _phoneListener.StartListening( _intExtension.ToString() );
        _apiState = ApiState.Listening;
    }
