                // Create the ToolTip and associate with the Form container.
                ToolTip toolTip = new ToolTip();
    
                // Set up the delays for the ToolTip.
                toolTip.AutoPopDelay = 15000;
                toolTip.InitialDelay = 300;
                toolTip.ReshowDelay = 300;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip.ShowAlways = true;
    
                // Set up the ToolTip text for the Buttons
                toolTip.SetToolTip(this.button2, "TooltipText1");
                toolTip.SetToolTip(this.button3, "TooltipText2");
