    public void ChangeContentControl(string kindContentControl)
    {
        switch (kindContentControl)
        {
            case "LogIn":
                {
                    var c = new LogInControl(); 
                    c.OnSuccessfulLogin += (senser, e) =>
                    {
                       ChangeContentControl("Check");
                    };
                    this.contentControl.Content = c;
                }
                break;
            case "Check":
                {
                    var c = new CheckControl();
                    c.LogOutClick += (senser, e) =>
                    {
                         ChangeContentControl("LogIn");
                    };
                    this.contentControl.Content = c;
                }
                break;
        }
    }
