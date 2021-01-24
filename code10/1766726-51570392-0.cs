    private ICommand abuttonClickedCommand;
    
    public ICommand AButtonClickedCommand => aButtonClickedCommand ?? (aButtonClickedCommand = new Command(ProcessButtonClickedCommand));
    
    private void ProcessButtonClickedCommand()
    {
    
       App.DB.IncrementPoints(Settings.cfs, phrasesFrame.phrase, (int)Settings.aBtn, 1);
       Change.points = true;
       phrasesFrame.CancelTimer2();
    
    }
