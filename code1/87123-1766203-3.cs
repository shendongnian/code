    //Your new authenticate code snippet:
            try
            {
                if (!LogonUser(user, domain, pass, LogonTypes.Network, LogonProviders.Default, out token))
                {
                    errorCode = Marshal.GetLastWin32Error();
                    success = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseHandle(token);    
            }            
            success = true;
