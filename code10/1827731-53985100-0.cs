    vm.Points = new String('☆', phrase.Points + pts);
    
    await Task.Run(() =>
    {
        App.DB.IncrementPoints(phrase, pts);
        App.DB.IncrementHistory(HIST.Views);
    });
    await Task.Delay(250);
