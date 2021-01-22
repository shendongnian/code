    public int Timer
    {
        set
        {
            if (this.InvokeRequired) 
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (value == 1)
                        this.timer.Enabled = true;
                    else
                        this.timer.Enabled = false;
                });
            }
            else
            {
                if (value == 1)
                    this.timer.Enabled = true;
                else
                    this.timer.Enabled = false;
            }
        }
    }
