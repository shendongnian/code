    public int TimerValue 
    {
    
        set
        {
            this.txtTextBox.Text = string.Format("{0:0000}", value);
    
        }
    }
