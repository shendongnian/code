    switch (kindContentControl)
    {
        case "LogIn":
        {
            ...
            this.contentControl.Content = new LogInControl(); <- here
        }
        break;
        
        case "Check":
        {
            ...
            this.contentControl.Content = new CheckControl(); <- here
        }
        break;
    }
