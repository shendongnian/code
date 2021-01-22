    if (!myCheckBox.Dispatcher.CheckAccess())
    {
        myCheckBox.Dispatcher.BeginInvoke(new Action(
        delegate()
        {
            myCheckBox.IsChecked = true;
        }
        ));
    }
    else
    {
        myCheckBox.IsChecked = true;
    }
