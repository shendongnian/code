    Dictionary<string, string> GetControls( List<string> controlNames )
    {
        Dictionary<string, string> retval = new Dictionary<string, string>();
        foreach( string controlName in controlNames ) {
        {
            // load the control
            Control ctrl = LoadControl("~/AllowedDynamicControls/" + controlName + ".ascx");
            // add to the dictionary
            retval.Add(controlName, ctrl.RenderToString() );
        }
    }
