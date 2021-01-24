     public void DoSomething()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(()=> DoSomething()));
                }
                else
                {
                   // update the ui from here, no worries
                }
            } 
