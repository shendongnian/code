    frame.Button(Find.ByName("go")).ClickNoWait();
    
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    stopwatch.Start();
    
    while (stopwatch.Elapsed.TotalMilliseconds < 3000d)
    {
        if (alertDialogHandler.Exists())
        {
            // Do whatever I want to do when there is an alert box.
            alertDialogHandler.OKButton.Click();
            break;
        }
    }
