    var yourToolTip = new ToolTip();
    //The below are optional, of course,
    
    yourToolTip.ToolTipIcon = ToolTipIcon.Info;
    yourToolTip.IsBalloon = true;
    yourToolTip.ShowAlways = true;
    
    yourToolTip.SetToolTip(dateTimePicker1, "Oooh, you put your mouse over me.");
