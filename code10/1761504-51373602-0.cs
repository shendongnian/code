    #if UNITY_EDITOR
    public async void PollCubePosition ( )
    {
        if ( pollCube ) return;
        pollCube = true;
    
        do
        {
            // Read cube data and perform whatever functions you want here..
    
            // Wait 1 seconds.
            await Task.Delay ( 1000 );
        } while ( pollCube );
    }
    #endif
