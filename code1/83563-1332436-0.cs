    public bool dcpl_radar()
    {
        if (radar == null)
            return false;
        else
        {
            if (radar != null)
            {
                if (radar.InvokeRequired)
                    radar.BeginInvoke(new MethodInvoker(delegate() 
                                                { 
                                                    radar.Visible = false; 
                                                    radar = null;
                                                }));
                else {
                    this.radar.Visible = false;
                    radar = null;
                }
                
            }
            return true;
        }//end of else statement
    }
