    public delegate void HiPathScreenPop_ShutdownEventHandler( object parent );
    class HiPathScreenPop
    {
        // Shutdown event, raised to terminate API running in separate thread
        public event HiPathScreenPop_ShutdownEventHandler Shutdown;
        private Thread _th;
        
        //ctor
        public HiPathScreenPop()
        {
            ...
            _th = new Thread( StartInBackground );
            _th.Start();
        }
        private void StartInBackground()
        {
            _phoneListener = new ScreenPopTelephoneListener();
            _apiState = ApiState.Allocated;
            _phoneListener.StatusChanged += new _IScreenPopTelephoneListenerEvents_StatusChangedEventHandler( StatusChangedEvent );
            _phoneListener.ScreenPop += new _IScreenPopTelephoneListenerEvents_ScreenPopEventHandler( ScreenPopEvent );
            this.Shutdown += new HiPathScreenPop_ShutdownEventHandler( HiPathScreenPop_Shutdown );
            _phoneListener.Initialize( _strAddress );
            _apiState = ApiState.Initialized;
            _phoneListener.StartListening( _intExtension.ToString() );
            _apiState = ApiState.Listening;
        }
        public void KillListener()
        {
            OnShutdown();
        }
        private void OnShutdown()
        {
            if ( this.Shutdown != null )
            {
                this.Shutdown( this );
            }
        }
        void HiPathScreenPop_Shutdown( object parent )
        {
            // code from previous posts
        }
    }
