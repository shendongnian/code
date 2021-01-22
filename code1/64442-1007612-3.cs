        private void Test(object data)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action<object>(Test), data);
            }
            else
            {
                /* do work */
            }
                
        }
