    // Clicks button to show texts
    //Displays text wanted basicly Text.Visibility =Visibility.Visible;
    DisplayWords();
    Application.DoEvents();
    //Waits x amount of seconds before hidden them
    System.Threading.Thread.Sleep(nbOfSecondsToWait * 1000);
    //Hide texts
