        private void Test()
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(Test));
            }
            else
            {
                /* do work */
            }
                
        }
