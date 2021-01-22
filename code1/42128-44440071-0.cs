    form_load()
    {
        ...
        foreach (Control ctl in groupbox.Controls) 
        {
            // load color value from parent and explicitly set it to control level
            ctl.ForeColor = ctl.ForeColor;
        }
        ...
    }
    some_click()
    {
        groupbox.ForeColor = Color.Pink;
    }
    someother_click()
    {
        groupbox.ForeColor = Color.Green; 
    }
