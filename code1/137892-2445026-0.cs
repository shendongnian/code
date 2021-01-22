        public void WriteExceptionToDisk(Exception exceptionLog)
        {           
            
                string loggingname = @"c:\Exception-" + DateTime.Today.Month.ToString() 
                                     + "-" + DateTime.Today.Day.ToString() + "-" +  
                                     DateTime.Today.Year.ToString() + ".txt";
                                     // Put the exception some where in the server but
                                     // make sure Read/Write permission is allowed.
                if (exceptionLog != null)
                {
                    message = "Exception Date and Time " + Environment.NewLine + "   ";
                    message = message + DateTime.Today.ToLongDateString() + " at ";
                    message = message + DateTime.Now.ToLongTimeString() + Environment.NewLine;
                    message = message + "Exception Message " + Environment.NewLine + "   " + exceptionLog.Message + Environment.NewLine;
                    message = message + "Exception Detail " + Environment.NewLine + exceptionLog.StackTrace;
                    message = message + Environment.NewLine;
                }
                else if (message == null || message == "" || exceptionLog == null)
                {
                    message = "Exception is not provided or is set as null.Please pass the exception.";
                }
                
                if (File.Exists(loggingname))// If logging name exists, then append the exception message
                {
                    message = Environment.NewLine + message;
                    File.AppendAllText(loggingname, message);
                }
                else
                {
                    StreamWriter streamwriter =  File.CreateText(loggingname);// Then create the file name
                    streamwriter.AutoFlush = true;
                    streamwriter.Write(message);
                    streamwriter.Close();
                }
         }
