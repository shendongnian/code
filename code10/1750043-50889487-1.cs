    void ShowRemaing()
    {
        int a = (int)((dt - DateTime.Now).TotalSeconds);
        if(a > 0)
        {
        SomeLabel.Text = $"{a} Seconds to enable";
        Device.StartTimer(new TimeSpan(0, 0, 1), ShowRemaing);
        }
    }
    
     private bool EnableButtonResend()
        {
            IsEnabledResend = true;
            return true;
        }
