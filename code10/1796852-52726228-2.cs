    public ObservableCollection<int> Draws {get;} = new ObservableCollection<int>();
    
    // Invoked from command, or could be a click handler until you learn commands
    public AddDraw()
    {
         int draw = GetNextDraw(); //Left as an exercise
         Draws.Add(draw)
    }
