    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.IO;
    using System.Net;
    using System.Reflection;
    
        public class WebServiceActivityLogger : SoapExtension
        {
            string fileName = null;
    
            public override object GetInitializer(Type serviceType)
            {
                return Path.Combine(@"C:\Your Destination Directory", serviceType.Name + " - " + DateTime.Now.ToString("yyyy-MM-dd HH.mm") + ".txt");
            }
    
            public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
            {
                return Path.Combine(@"C:\Your Destination Directory", methodInfo.DeclaringType.Name + " - " + DateTime.Now.ToString("yyyy-MM-dd HH.mm") + ".txt");
            }
    
            public override void Initialize(object initializer)
            {
                fileName = initializer as string;
            }
    
            Dictionary<int, ActivityLogData> logDataDictionary = new Dictionary<int, ActivityLogData>();
            private ActivityLogData LogData
            {
                get
                {
                    ActivityLogData rtn;
                    if (!logDataDictionary.TryGetValue(System.Threading.Thread.CurrentThread.ManagedThreadId, out rtn))
                        return null;
                    else
                        return rtn;
                }
                set
                {
                    int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                    if(logDataDictionary.ContainsKey(threadId))
                    {
                        if (value != null)
                            logDataDictionary[threadId] = value;
                        else
                            logDataDictionary.Remove(threadId);
                    }
                    else if(value != null)
                        logDataDictionary.Add(threadId, value);
                }
            }
    
            private class ActivityLogData
            {
                public string methodName;
                public DateTime startTime;
                public DateTime endTime;
                public Stream transportStream;
                public Stream accessStream;
                public string inputSoap;
                public string outputSoap;
                public bool endedInError;
            }
    
            public override Stream ChainStream(Stream stream)
            {
                if (LogData == null)
                    LogData = new ActivityLogData();
                var logData = LogData;
    
                logData.transportStream = stream;
                logData.accessStream = new MemoryStream();
                return logData.accessStream;
            }
    
            public override void ProcessMessage(SoapMessage message)
            {
                if (LogData == null)
                    LogData = new ActivityLogData();
                var logData = LogData;
    
                if (message is SoapServerMessage)
                {
                    switch (message.Stage)
                    {
                        case SoapMessageStage.BeforeDeserialize:
                            //Take the data from the transport stream coming in from the client
                            //and copy it into inputSoap log.  Then reset the transport to the beginning
                            //copy it to the access stream that the server will use to read the incoming message.
                            logData.startTime = DateTime.Now;
                            logData.inputSoap = GetSoapMessage(logData.transportStream);
                            Copy(logData.transportStream, logData.accessStream);
                            logData.accessStream.Position = 0;
                            break;
                        case SoapMessageStage.AfterDeserialize:
                            //Capture the method name after deserialization and it is now known. (was buried in the incoming soap)
                            logData.methodName = GetMethodName(message);
                            break;
                        case SoapMessageStage.BeforeSerialize:
                            //Do nothing here because we are not modifying the soap
                            break;
                        case SoapMessageStage.AfterSerialize:
                            //Take the serialized soap data captured by the access stream and
                            //write it into the log file.  But if an error has occurred write the exception details.
                            logData.endTime = DateTime.Now;
                            logData.accessStream.Position = 0;
                            if (message.Exception != null)
                            {
                                logData.endedInError = true;
                                if (message.Exception.InnerException != null && message.Exception is System.Web.Services.Protocols.SoapException)
                                    logData.outputSoap = GetFullExceptionMessage(message.Exception.InnerException);
                                else
                                    logData.outputSoap = GetFullExceptionMessage(message.Exception);
                            }
                            else
                                logData.outputSoap = GetSoapMessage(logData.accessStream);
    
                            //Transfer the soap data as it was created by the service
                            //to the transport stream so it is received the client unmodified.
                            Copy(logData.accessStream, logData.transportStream);
                            LogRequest(logData);
                            break;
                    }
                }
                else if (message is SoapClientMessage)
                {
                    throw new NotSupportedException("This extension must be ran on the server side");
                }
    
            }
    
            private void LogRequest(ActivityLogData logData)
            {
                try
                {
                    //Create the directory if it doesn't exist
                    var directoryName = Path.GetDirectoryName(fileName);
                    if (!Directory.Exists(directoryName))
                        Directory.CreateDirectory(directoryName);
    
                    using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                    {
                        var sw = new StreamWriter(fs);
    
                        sw.WriteLine("--------------------------------------------------------------");
                        sw.WriteLine("- " + logData.methodName + " executed in " + (logData.endTime - logData.startTime).TotalMilliseconds.ToString("#,###,##0") + " ms");
                        sw.WriteLine("--------------------------------------------------------------");
                        sw.WriteLine("* Input received at " + logData.startTime.ToString("HH:mm:ss.fff"));
                        sw.WriteLine();
                        sw.WriteLine("\t" + logData.inputSoap.Replace("\r\n", "\r\n\t"));
                        sw.WriteLine();
                        if (!logData.endedInError)
                            sw.WriteLine("* Output sent at " + logData.endTime.ToString("HH:mm:ss.fff"));
                        else
                            sw.WriteLine("* Output ended in Error at " + logData.endTime.ToString("HH:mm:ss.fff"));
                        sw.WriteLine();
                        sw.WriteLine("\t" + logData.outputSoap.Replace("\r\n", "\r\n\t"));
                        sw.WriteLine();
                        sw.Flush();
                        sw.Close();
                    }
                }
                finally
                {
                    LogData = null;
                }
            }
    
            private void Copy(Stream from, Stream to)
            {
                TextReader reader = new StreamReader(from);
                TextWriter writer = new StreamWriter(to);
                writer.WriteLine(reader.ReadToEnd());
                writer.Flush();
            }
    
            private string GetMethodName(SoapMessage message)
            {
                try
                {
                    return message.MethodInfo.Name;
                }
                catch 
                {
                    return "[Method Name Unavilable]";
                }
            }
    
            private string GetSoapMessage(Stream message)
            {
                if(message == null || message.CanRead == false)
                    return "[Message Soap was Unreadable]";
                var rtn = new StreamReader(message).ReadToEnd();
                message.Position = 0;
                return rtn;
            }
    
            private string GetFullExceptionMessage(System.Exception ex)
            {
                Assembly entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
                string Rtn = ex.Message.Trim() + "\r\n\r\n" +
                    "Exception Type: " + ex.GetType().ToString().Trim() + "\r\n\r\n" +
                    ex.StackTrace.TrimEnd() + "\r\n\r\n";
                if (ex.InnerException != null)
                    Rtn += "Inner Exception\r\n\r\n" + GetFullExceptionMessage(ex.InnerException);
                return Rtn.Trim();
            }
        }
