     private void SetupEventHandlers(RGBButton button,string EventName, string MethodName)
            {
                // THIS SETS UP THE EVENT HANDLER THAT WILL FIRE ANY ADDITION 
                // ACTIONS THE USER COULD WANT WHEN A BUTTON IS PRESSED OR RELEASED.
                var p = button;
                var eventInfo = p.GetType().GetEvent(EventName);
                var methodInfo = typeof(RGBButton).GetMethod(MethodName);
                
                try
                {
                    // TRY TO SUBSCRIBE TO OUR KEYUP OR KEYDOWN EVENT
                    Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, p, methodInfo);
                    eventInfo.AddEventHandler(p, handler);
                }
                catch (Exception)
                {
                    // MOST LIKELY COULDN'T FIND THE METHOD WE ARE TRYING TO FIRE
                    throw new System.InvalidOperationException("Failed to find method: " + MethodName + "', which is registered as an Event Subscriber.");
                }
                
    
            }
