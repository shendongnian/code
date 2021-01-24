                try
                {
                    tracingService.Trace("Attempting to obtain Phone value...");
                    phone = account["telephone1"].ToString();
                            
                }
                    
                catch(Exception error)
                {
                    tracingService.Trace("Failed to obtain Phone field. Error Details: " + error.ToString());
                    throw new InvalidPluginExecutionException("A problem has occurred. Please press OK to continue using the application.");
                }
