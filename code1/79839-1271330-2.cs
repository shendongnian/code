    using System;
    using System.IO;
    
    namespace LogProvider
    {
        //
        // Example Logger Class
        //
        public class Logging
        {
            public static string LogDir { get; set; }
            public static string LogFile { get; set; }
            private static readonly Random setere = new Random();
            private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
            public Logging() {
                LogDir = null;
                LogFile = null;
            }
            public static string RandomFileName()
            {
                char[] buffer = new char[5];
                for (int i = 0; i < 5; i++)
                {
                    buffer[i] = chars[setere.Next(chars.Length)];
                }
                return new string(buffer);
            }
    
    
            public static void AddLog(String msg)
            {
                String tstamp = Convert.ToString(DateTime.Now.Day) + "/" +
                                Convert.ToString(DateTime.Now.Month) + "/" +
                                Convert.ToString(DateTime.Now.Year) + " " +
                                Convert.ToString(DateTime.Now.Hour) + ":" +
                                Convert.ToString(DateTime.Now.Minute) + ":" +
                                Convert.ToString(DateTime.Now.Second);
    
                if(LogDir == null || LogFile == null) 
                {
                   throw new ArgumentException("Null arguments supplied");
                }
                String logFile = LogDir + "\\" + LogFile;
                String rmsg = tstamp + "," + msg;
    
                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine(rmsg);
                sw.Flush();
                sw.Close();
            }
        }
    }
