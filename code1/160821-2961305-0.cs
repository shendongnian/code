        private void procExit(object sender, EventArgs e)
        {
            MessageBox.Show("YAY", "WOOT");
            Thread.Sleep(2000);
            // ProcessStatus is just a class I made up to demonstrate passing data back to the UI
            processComplete(new ProcessStatus { Success = true });
        }
        private void processComplete(ProcessStatus status)
        {
            if (this.InvokeRequired)
            {
                // We are in the wrong thread!  We need to use BeginInvoke in order to execute on the correct thread.
                // create a delegate pointing back to this same function, passing in the same data
                this.BeginInvoke(new Action<ProcessStatus>(this.processComplete), status);
            }
            else
            {
                // check status info
                if (status.Success)
                {
                    // handle success, if applicable
                }
                else
                {
                    // handle failure, if applicable
                }
                    
                // this line of code is now safe to execute, because the BeginInvoke method ensured that the correct thread was used to execute this code.
                launchbutton.Enabled = true;
            }
        }
