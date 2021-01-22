    IObservable<Position> mouseMove = GetMouseMove(); // stream of MouseMove events
    IObservable<Position> manualTrigger = new Subject<Position>();
    
    var positionChange = mouseMove.Merge(manualTrigger);
    positionChange.Subscribe(pos => ...);
