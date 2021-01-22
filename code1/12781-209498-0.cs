    if (success)
                    {
                        lblSuccessMessage.Text = _successMessage;
                        showMessage(true);                        
                    }
                    else
                    {
                        lblSuccessMessage.Text = _failureMessage;
                        showMessage(false);
                    }
    
                    if(success) {
                        Threading.Thread.Sleep(200)
                        Response.Redirect(_downloadURL);
                    }
