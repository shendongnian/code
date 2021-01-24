    public event EventHandler ItemAdded;
    
    public void RaiseItemAdded()
    {
    	ItemAdded(this, EventArgs.Empty);
    }
    
    
    //have to close return call back after item addition in MyPage	
    public async void CallPopAsync()
    {
    	await Navigation.PopAsync();
    }
