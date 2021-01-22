    public bool dcpl_radar()
    {
        if (radar != null)
        {
            if (radar.InvokeRequired)
            {
                radar.BeginInvoke(new MethodInvoker(HideRadar));
            }
            else
            {
                HideRadar();
            }
        
            return true;
        }
        
        return false;
    }
    private void HideRadar()
    {
        this.radar.Visible = false;
        this.radar = null;
    }
