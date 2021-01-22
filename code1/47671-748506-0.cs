    private enum ApiState { Unallocated, Allocated, Initialized, Listening };
    private ApiState _apiState = ApiState.Unallocated;
    private void StartInBackground()
    {
      _listener = new ScreenPopTelephoneListener();
      _apiState = ApiState.Allocated;
      _phoneListener.Initialize( _strAddress );
      _apiState = ApiState.Initialized;
      _phoneListener.StartListening( _intExtension.ToString() );
      _apiState = ApiState.Listening;
    }
    public void ShutdownFunc
    {
      try
      {
        if ( ApiState.Listening == _apiState )
        {
          _listener.StopListening();
          _listener.Shutdown();
        }
        if ( ApiState.Initialized == _apiState )
        {
          _listener.Shutdown();
        }
      }
      catch {}
      finally
      {
        _listener = null;
        _apiState = ApiState.Unallocated;
      }
    }
