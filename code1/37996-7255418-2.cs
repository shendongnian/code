    private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        string str = e.Parameter as string;
        switch (str)
        {
            case null://F1 Pressed default Help
                   //Code
                break;
            case "Case1":
                   //Code
                break;
            case "Case2":
                   //Code
                break;
            case "Case3":
                   //Code
                break;
            case "Case4":
                break;
            case "Case5":
                   //Code
                break;
            case "Case6":
                   //Code
                break;
            case "Case7":
                   //Code
                break;
        }
        e.Handled = true;
    }
