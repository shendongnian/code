    void SomeFunction()
    {
    // Do work in background worker
    //Will return less than 8 if there are no error message from the library 
            if (!this.bgwProcessLogin.CancellationPending)
            {
                    // Register and wait for response
                    VaxSIPUserAgentOCX.RegisterToProxy(3600);
            }
            else
            {
                    // Update label
                    if (this.lblRegistering.InvokeRequired)
                    {
                      // do something here
                    }
                    else
                    {
                        // Display error
                    }
             }
    
    // WAIT FOR A RESPONSE FROM THE DIAGNOTIC EVENT BEFORE CONTINUING - MAYBE JOIN HERE
    
            waitEvent.WaitOne();
            if (!this.bgwProcessLogin.CancellationPending)
            {
                if (this.responseFlag)
                {
                    // Do something here   
                }
                else
                {
                    // Do something else here
                }
            }
    }
    
    ManualResetEvent waitEvent = new ManualResetEvent(false);
            
    // Another function where I receive the response
    private void VaxSIPUserAgentOCX_OnIncomingDiagnostic(object sender, AxVAXSIPUSERAGENTOCXLib._DVaxSIPUserAgentOCXEvents_OnIncomingDiagnosticEvent e)
        {
            string messageSip = e.msgSIP;
            //Find this message in the sip header
    
            string sipErrorCode = "600 User Found"; 
            if (messageSip.Contains(sipErrorCode))
            {
                // Set global flag for response
                this.responseFlag = true;
                waitEvent.Set();
            }
    }
