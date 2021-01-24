    private bool nameChanged = false;
    private string claimnumber;
    public string ClaimNumber
    {
        get { return this.claimnumber; }
        set
        {
            this.claimnumber = value;
            nameChanged = true;
 
        }
    }
    AddNew = new RelayCommand(o => startbutton());
    stop = new RelayCommand(o => stopbutton());
    public void startbutton()
    {
    
        stopWatch.Start();
        dispatcherTimer.Start();
        IsEnabled = true;
        IsStartButtonEnabled = false;
    }
    public void stopbutton()
    {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
            IsEnabled = false;
      //The claimnumber made empty whenever i click end the button
            ClaimNumber = null;
     // Here i made the boolean to false so the error message will not be triggered.
            nameChanged = false;
     // Now the claimnumber which i emptied above should be reflected in the view
            this.onPropertyChanged("Clainumber");
    }
       private string GetValidationError(string propertyName)
      {
        string errorMsg = null;
        switch (propertyName)
        {
            case "ClaimNumber":
                if ((nameChanged && propertyName.Equals("ClaimNumber")))
                {
                    if (String.IsNullOrEmpty(this.claimnumber))
                        errorMsg = "Please provide the claimnumber";
                    else if (CheckInteger(claimnumber) == false)
                        errorMsg = "The given claimnumberis not a Number";
                }
                break;
    }
    }
