        static public bool DumpLog(string device, string LogName, string outputPathOnRemoteSystem, out string errMessage)
        {
            bool wasExported = false;
            string errorMessage = "";
            try
            {
                System.Diagnostics.Eventing.Reader.EventLogSession els = new System.Diagnostics.Eventing.Reader.EventLogSession(device);
                els.ExportLogAndMessages(LogName, PathType.LogName, "*", outputPathOnRemoteSystem);
                wasExported = true;
            }
            catch (UnauthorizedAccessException e)
            {
                errorMessage = "Unauthorized - Access Denied: " + e.Message;
            }
            catch (EventLogNotFoundException e)
            {
                errorMessage = "Event Log Not Found: " + e.Message;
            }
            catch (EventLogException e)
            {
                errorMessage = "Export Failed: " + e.Message + ", Log: " + LogName + ", Device: " + device;
            }
            errMessage = errorMessage;
            return wasExported;
        }
