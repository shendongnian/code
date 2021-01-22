    // the Window class exposes a Dispatcher property, alternatively you could use
    // InputBox.Dispatcher to the same effect
    if (!Dispatcher.CheckAccess())
         {
            Dispatcher.Invoke(new Action(() => ChangeForegroundColor(percentageDone));
         }
         else
         {
            ChangeForegroundColor(percentageDone);
         }
    ...
    private void ChangeForegroundColor(int percentageDone)
    {
        if (percentageDone >= 90)
        {
            InputBox.Foreground = new SolidColorBrush(Colors.Red);
        }
        else if(percentageDone >=10)
        {
            InputBox.Foreground = new SolidColorBrush(Colors.Orange);
        }
    }
