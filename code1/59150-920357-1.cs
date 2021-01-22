    public void z1Safe()
            {
    
                for (int i = 1; i < 60; ++i)
                {
                    progressBar1.Value += 1;
                    for (int j = 1; j < 10000000; ++j)
                    {
                        j += 1;
                    }
                }
            }
    
            public void z1()
            {
    
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate { z1Safe(); });
                }
                else
                    z1Safe();
            }
