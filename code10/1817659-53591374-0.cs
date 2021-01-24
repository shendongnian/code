     private bool Reload(object param = null)
    {
        var type = Frame.CurrentSourcePageType;
        try
        {
            return Frame.Navigate(type, param);
        }
        finally
         {
            Frame.BackStack.Remove(Frame.BackStack.Last());
         }
    }
