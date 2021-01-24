    private bool On_BackRequested()
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame.Content is Page3 page3 )
        {
             var innerFrame = page3.GetInnerFrame(); //implement this method in Page3
             if (innerFrame.CanGoBack)
             {
                 innerFrame.GoBack();
                 return true;
             }
        } 
        
        if (rootFrame.CanGoBack)
        {
            rootFrame.GoBack();
            return true;
        }
        return false;
    }
