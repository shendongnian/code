    foreach (Control control in this.Controls)
    {
    
        // #2
        MdiClient client = control as MdiClient;
        if (!(client == null))
        {
        	// #3
        	client.BackColor = GetYourColour();
        	// 4#
        	break;
        }
    }
