    string userName = "domain\\user"; // there's really just one slash, 
    //but you have to escape it if hard-coding.. 
    //if brought in by a text box, it would be just domain\user
    string password = "whatever";
    
    WindowsImpersonationContext adminContext = Impersonation.getWic(userName, password);
    if (adminContext != null)
    {
       try
       {
            ServiceController sc = new ServiceController("YourService", "MachineName");
            if (sc.Status.Equals(ServiceControllerStatus.Stopped) || 
                sc.Status.Equals(ServiceControllerStatus.StopPending))
            {
                // it is stopped
            }
        }
        catch (Exception ex)
        {
            Console.Out.WriteLine("\nUnable to set profile to Mandatory:\n\t" + ex.Message);
            Impersonation.endImpersonation();
            adminContext.Undo();
        }
        finally
        {
            Impersonation.endImpersonation();
            // The above line just basically does this on the tokens --            
            //if (tokenHandle != IntPtr.Zero) CloseHandle(tokenHandle);
            adminContext.Undo();
        }
    }
