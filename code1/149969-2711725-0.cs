    private void UpdateLabel(string tekst)
        {
            if (label.Dispatcher.CheckAccess() == false)
            {
                updateLabelCallback uCallBack = new updateLabelCallback(UpdateLabel);
                this.Dispatcher.Invoke(uCallBack, tekst);
            }
            else
            { 
		//update your label here
	        }
	     }
    
