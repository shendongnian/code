 private void SelfTransferCompleted(IAsyncResult asyncResult)
        {
            Exception exceptionCaught = null;
           // bool exceptionEncountered = true;
            try
            {
                _flow.Call.EndTransfer(asyncResult);
                //Self Transfer has completed. successfully.
                exceptionEncountered = false;
                LogHelper.Log(LogTarget.FileEvent, "IVR Menu Ended self tranfer for call>" +_flow.Call.CallId);
                // cleaning up atten
                string sqlstring = "update astsxqueue set uniqueid ='" + _server.b2bCallDelId + "' where uniqueid='" + _flow.Call.CallId + "';";
                LogHelper.Log(LogTarget.FileEvent, sqlstring);
                _server.mconnector.Mysqlqueryruner(sqlstring);
            }
            catch (OperationTimeoutException orte)
            {
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted Operation Timeout Exception: " + orte.ToString(), 2);
                exceptionCaught = orte;
                exceptionEncountered = true;
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Trying to transfer to other agent...", 2);
                RetrieveCallAfterTransferFailure();
                //_flow.Call.BeginTransfer("tel:+123456", null/*transferOptions*/, this.SelfTransferCompleted, _flow.Call);
                // _inboundAVCall.Flow.Call.BeginTransfer("tel:+123456", _server.EndTransferCall, _inboundAVCall.Flow.Call);
                //_flow.Call.BeginTransfer("tel:+123456", _server.EndTransferCall, _flow.Call);
                // Wait for the call to complete the transfer.
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Waiting for transfer to complete...");
                _server._waitForTransferComplete.WaitOne();
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Transfer completed.");
            }
            catch (FailureResponseException frte)
            {
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Failure Exception = {0}" + frte.ToString(), 2);
                exceptionCaught = frte;
                exceptionEncountered = true;
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Trying to transfer to other agent...", 2);
                //_flow.Call.BeginTransfer("tel:+123456", null/*transferOptions*/, this.SelfTransferCompleted, _flow.Call);
                // _inboundAVCall.Flow.Call.BeginTransfer("tel:+123456", _server.EndTransferCall, _inboundAVCall.Flow.Call);
                //_flow.Call.BeginTransfer("tel:+123456", _server.EndTransferCall, _flow.Call);
                // Wait for the call to complete the transfer.
                RetrieveCallAfterTransferFailure();
                LogHelper.Log(LogTarget.FileEvent, "Waiting for transfer to complete...");
                _server._waitForTransferComplete.WaitOne();
                LogHelper.Log(LogTarget.FileEvent, "Transfer completed.");
            }
            catch (RealTimeException rte)
            {
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Realtime Exception = {0}" + rte.ToString(),2);
                exceptionCaught = rte;
                exceptionEncountered = true;
                LogHelper.Log(LogTarget.FileEvent, "IVR SelfTransferCompleted  Trying to transfer to other agent...", 2);
                RetrieveCallAfterTransferFailure();
                LogHelper.Log(LogTarget.FileEvent, "IVR Call is retreived waiting a bit...", 2);
               // Thread.Sleep(2000);
                LogHelper.Log(LogTarget.FileEvent, "IVR Call is retreived time passed...", 2);
               // _flow.EndHold(null);
             //   _speechSynthesizer.Speak("We did not get to a green agent. Please retry your option!");  //TEXT TO SPEEECH!
              // SpeakMenuOptions();
             // toneController.ToneReceived += toneController_ToneReceived;
                // Wait for the call to complete the transfer.
                LogHelper.Log(LogTarget.FileEvent, "Waiting for transfer to complete...");
                //_server._waitForTransferComplete.Set();
                LogHelper.Log(LogTarget.FileEvent, "Transfer completed.");
                
            }
           
        }
        private void RetrieveCallAfterTransferFailure()
        {
            // Take the call off of hold after a transfer fails.
            LogHelper.Log(LogTarget.FileEvent, "IVR Trying to retrive from Self transfer ...", 2);
            try
            {
                _flow.BeginRetrieve(retrieveResult =>
                {
                    try
                    {
                        LogHelper.Log(LogTarget.FileEvent, "IVR  Trying to retrive from Self transfer ...", 2);
                        Thread.Sleep(1000);
                        _flow.EndRetrieve(retrieveResult);
                       
                        LogHelper.Log(LogTarget.FileEvent, "IVR  Successfully retrieved call. Waiting a bit");
                        LogHelper.Log(LogTarget.FileEvent, "IVR Call is retreived time passed...", 1);
                        //_flow.EndHold(retrieveResult);
                        Thread.Sleep(2000);
           //             _flow.EndRetrieve(retrieveResult);
               //         _speechSynthesizer.Speak("A green agent is busy. Please retry your option!");  //TEXT TO SPEEECH!
                 //       SpeakMenuOptions();
                   //    toneController.ToneReceived += toneController_ToneReceived;
                       
                    }
                    catch (RealTimeException rtex)
                    {
                        LogHelper.Log(LogTarget.FileEvent, "IVR  Failed retrieving call." + rtex);
                    }
                },
                null);
            }
            catch (InvalidOperationException ioex)
            {
                LogHelper.Log(LogTarget.FileEvent, "IVR Failed retrieving call."+ ioex);
            }
        }
After adding the above code I get it working.
Thanks.
