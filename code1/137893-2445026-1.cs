        public void WriteExceptionToDisk(Exception exceptionLog)
        {
            string loggingname = @"c:\Exception-" + DateTime.Today.Month.ToString()
                                 + "-" + DateTime.Today.Day.ToString() + "-" +
                                 DateTime.Today.Year.ToString() + ".txt";
            // Put the exception some where in the server but
            // make sure Read/Write permission is allowed.
            StringBuilder message = new StringBuilder();
            if (exceptionLog != null)
            {
                message.Append("Exception Date and Time ");
                message.AppendLine(); 
                message.Append("   ");
                message.Append(DateTime.Today.ToLongDateString() + " at ");
                message.Append(DateTime.Now.ToLongTimeString());
                message.AppendLine();
                message.Append("Exception Message ");
                message.AppendLine(); message.Append("   ");
                message.Append(exceptionLog.Message);
                message.AppendLine();
                message.AppendLine("Exception Detail ");
                message.AppendLine();
                message.Append(exceptionLog.StackTrace);
                message.AppendLine();
            }
            else if (message == null || exceptionLog == null)
            {
                message.Append("Exception is not provided or is set as null.Please pass the exception.");
            }
            if (File.Exists(loggingname))// If logging name exists, then append the exception message
            {
                
                File.AppendAllText(loggingname, message.ToString());
            }
            else
            {
                // Then create the file name
                using (StreamWriter streamwriter = File.CreateText(loggingname))
                {
                    streamwriter.AutoFlush = true;
                    streamwriter.Write(message);
                    streamwriter.Close();
                }                 
            }
        }
