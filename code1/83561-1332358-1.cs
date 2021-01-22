    public bool dcpl_radar()
    {
        if (radar != null)
        {
            if (radar.InvokeRequired)
            {
                radar.BeginInvoke(new MethodInvoker(() => { radar.Visible = false; }));
            }
            else
            {
                this.radar.Visible = false;
            }
            radar = null;
        
            return true;
        }
        
        return false;
    }
