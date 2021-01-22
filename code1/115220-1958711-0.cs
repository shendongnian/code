    var startObs = Observable.FromEvent<StartGameCompletedEventArgs>(
                      h => m_Server.StartGameCompleted += h,
                      h => m_Server.StartGameCompleted -= h )
            .Take(1) // necessary to ensure the observable unsubscribes
            .ObserveOnDispatcher(); // controls which thread the observer runs on
    
    startObs.Subscribe( e => { m_gameState = e.EventArgs.Result.StartGameResult;
                               if( m_GameState.Bankroll < Game.MinimumBet )
                                   NotifyPlayer( ... );  // some UI code here ...
                               TransitionVisual( GameVisualState.HandNotStarted );
                             } );  // this code now executes with access to the UI
    
    m_Server.StartGameAsync();  // initiates the call to the WCF service
