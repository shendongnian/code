    ClocksList clocks = new ClocksList();
    // Fill the list
    clocks.Add(new Clock());
    ...
    // Move time on all clocks
    clocks.MoveAllClocks();
    // Move single clock
    Clock c = new Clock();
    clocks.Add(c);
    clocks.MoveSingleClock(c);
