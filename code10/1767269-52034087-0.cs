    protected override void OnStop()
    {
        try
        {
            if (_ESSServiceHost != null)
            {
                Tools.LogInfo("Stopping ESService.");
                var abortTask = Task.Run(() => _ESSServiceHost.Abort());
                var closeTask = Task.Run(() => _ESSServiceHost.Close(TimeSpan.FromSeconds(300)));
                try
                {
                    if (_ESSServiceHost.State == CommunicationState.Faulted)
                    {
                        Tools.LogInfo("ESSServiceHost.State == CommunicationState.Faulted");
                        if (!abortTask.Wait(TimeSpan.FromSeconds(60)))
                            Tools.LogInfo("Failed to Abort.");
                    }
                    else
                    {
                        if (!closeTask.Wait(TimeSpan.FromSeconds(301)))
                        {
                            Tools.LogInfo("Failed to Close - trying Abort.");
                            if (!abortTask.Wait(TimeSpan.FromSeconds(60)))
                                Tools.LogInfo("Failed to Abort.");
                        }                            
                    }
                }
                catch (Exception ex)
                {
                    Tools.LogException(ex, "ESSServiceHost.Close");
                    try
                    {
                        Tools.LogInfo("Abort.");
                        if (!abortTask.Wait(TimeSpan.FromSeconds(60)))
                            Tools.LogInfo("Failed to Abort.");
                    }
                    catch (Exception ex2)
                    {
                        Tools.LogException(ex2, "ESSServiceHost.Abort");
                    }
                }
                _ESSServiceHost = null;
                Tools.LogInfo("ESService stopped.");
            }
        }
        catch (Exception ex)
        {
            Tools.LogException(ex,"OnStop");
        }
    }
