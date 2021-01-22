     MdiClient ctlMDI;
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        ctlMDI = (MdiClient)ctl;
    
                        // Set the BackColor of the MdiClient control.
                        ctlMDI.BackColor = Color.DarkRed;
                    }
                    catch (InvalidCastException exc)
                    {
                        // Catch and ignore the error if casting failed.
                    }
                }
