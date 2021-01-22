            var machineName = "mymachine01";
            var formatName = "FormatName:DIRECT=OS:mymachine01\private$\ftpreceived":
            try
            {
                var msmqManagement = new MSMQ.MSMQManagement();
                msmqManagement.Init(machineName, null, formatName );
                return (uint)msmqManagement.MessageCount;
            }
            catch (COMException ex)
            {
                // If queue is not active or does not exist.
                if (ex.ErrorCode == -1072824316)
                {
                    return 0;
                }
                throw;
            }
