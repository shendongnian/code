    protected override async void OnLoadAsync( EventArgs e )
    {
        base.OnLoad( e );
    
        try
        {
            IsLiveProgress = true;
            await StartCurrentRunAsync( true );
        }
        catch ( Exception ex )
        {
            CreateEventLogs.WriteToEventLog( string.Format( "{0} - {1}" , "Error occured during Run" , ex.Message ) , LogInformationType.Error );
        }
        finally
        {
            IsLiveProgress = false;
        }
    }
    
    private Task StartCurrentRunAsync( bool obj )
    {
        StartTimer();
        PropertyCallBackChangedInstance.PropertyChanged -= PropertyCallBackChangedInstance_PropertyChanged;
        WhenCancelledBlurVolumesGrid = false;
        OriginalTime = SelectedVolumeEstimatedTime();
    
        return Task.Run( () =>
        {
            CreateEventLogs.WriteToEventLog( string.Format( "Run with Assay:{0} Volume{1} has been started" , SelectedAssay , SelectedVolume ) ,
                LogInformationType.Info );
            var instance = ConnectToInstrument.InstrumentConnectionInstance;
            return instance.InitalizeRun( PopulateRespectiveVolumes() );
        } );
    }
    
    private void PropertyCallBackChangedInstance_PropertyChanged( object sender , PropertyChangedEventArgs e )
    {
        //bool stepDone = false;
        if ( e.PropertyName == "RunStepStatusName" )
        {
            var value = sender as InstrumentCallBackProperties;
            Dispatcher.CurrentDispatcher.BeginInvoke( ( Action ) ( () =>
            {
                CurrentStatus = value.RunStepStatusName;
    
                if ( value.RunStepStatusName == "Step5" )
                {
                    WorkDone = true;
                }
            } ) );
            //stepDone = true;
        }
    }
