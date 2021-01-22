    public bool setGroup(Control ctrl)
        {
            isAControl = false;
    
            //set a section to true, so it will pull the html
            if (ctrl.ID.StartsWith("GenInfo_"))
            {
                GenInfo = true;
                lstControls.Add(ctrl.ID.Replace("GenInfo_", ""));
                isAControl = true;
                return isAControl;
            }
