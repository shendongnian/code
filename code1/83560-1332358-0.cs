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
        
            return true;
        }
        
        return false;
    }
