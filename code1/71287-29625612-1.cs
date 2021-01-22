    using System.IO;
    using System.Xml;
    using System.Threading;
    public class BBALogger
        {
            public enum MsgType
            {
                Error ,
                Info 
            }
    
            public static BBALogger Instance
            {
                get
                {
                    if (_Instance == null)
                    {
                        lock (_SyncRoot)
                        {
                            if (_Instance == null)
                                _Instance = new BBALogger();
                        }
                    }
                    return _Instance;
                }
            }
    
            private static BBALogger _Instance;
            private static object _SyncRoot = new Object();
            private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
    
            private BBALogger()
            {
                LogFileName = DateTime.Now.ToString("dd-MM-yyyy");
                LogFileExtension = ".xml";
                LogPath= Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Log";
            }
    
            public StreamWriter Writer { get; set; }
    
            public string LogPath { get; set; }
    
            public string LogFileName { get; set; }
    
            public string LogFileExtension { get; set; }
    
            public string LogFile { get { return LogFileName + LogFileExtension; } }
    
            public string LogFullPath { get { return Path.Combine(LogPath, LogFile); } }
    
            public bool LogExists { get { return File.Exists(LogFullPath); } }
    
            public void WriteToLog(String inLogMessage, MsgType msgtype)
            {
                _readWriteLock.EnterWriteLock();
                try
                {
                    LogFileName = DateTime.Now.ToString("dd-MM-yyyy");
    
                    if (!Directory.Exists(LogPath))
                    {
                        Directory.CreateDirectory(LogPath);
                    }
    
                    var settings = new System.Xml.XmlWriterSettings
                    {
                        OmitXmlDeclaration = true,
                        Indent = true
                    };
    
                    StringBuilder sbuilder = new StringBuilder();
                    using (StringWriter sw = new StringWriter(sbuilder))
                    {
                        using (XmlWriter w = XmlWriter.Create(sw, settings))
                        {
                            w.WriteStartElement("LogInfo");
                            w.WriteElementString("Time", DateTime.Now.ToString());
                            if (msgtype == MsgType.Error)
                                w.WriteElementString("Error", inLogMessage);
                            else if (msgtype == MsgType.Info)
                                w.WriteElementString("Info", inLogMessage);
    
                            w.WriteEndElement();
                        }
                    }
                    using (StreamWriter Writer = new StreamWriter(LogFullPath, true, Encoding.UTF8))
                    {
                        Writer.WriteLine(sbuilder.ToString());
                    }
                }
                catch (Exception ex)
                {
    
                }
                finally
                {
                    _readWriteLock.ExitWriteLock();
                }
            }
    
            public static void Write(String inLogMessage, MsgType msgtype)
            {
                Instance.WriteToLog(inLogMessage, msgtype);
            }
        }
