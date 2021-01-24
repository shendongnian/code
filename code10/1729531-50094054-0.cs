    public string MyCustomFormatProperty{
        get {
            return string.Format("ID:{0}",  this.XXX);
        }
    }
    
    <Label Text = "{Binding MyCustomFormatProperty}" />
