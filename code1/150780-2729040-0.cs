    private void UpdateElement(string tekst)
    {
        if (element.Dispatcher.CheckAccess() == false)
        {
            updateCallback uCallBack = new updateCallback(UpdateElement);
            this.Dispatcher.Invoke(uCallBack, tekst);
        }
        else
        { 
    //update your element here
        }
     }
