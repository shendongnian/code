    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    // add
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.IO;
    using System.Timers;
    namespace LogToFile
    {
        class Program
        {
            public static Logger logger = new Logger("debug.log");
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                logger.add("[001][LOGGER STARTING]");
                Thread t0 = new Thread(() => DoWork("t0"));
                t0.Start();
                Thread t1 = new Thread(() => DoWork("t1"));
                t1.Start();
                Thread t2 = new Thread(() => DoWork("t2"));
                t2.Start();
                Thread ts = new Thread(() => SaveWork());
                ts.Start();
            }
            public static void DoWork(string nr){
                while(true){
                    logger.add("Hello from worker .... number " + nr);
                    Thread.Sleep(300);
                }
            }
            public static void SaveWork(){
                while(true){
                    logger.saveNow();
                    Thread.Sleep(100);
                }
            }
        }
        class Logger
        {
            // Kolejka logger
            public Queue logs = new Queue();
            public string path = "debug.log";
            public Logger(string path){
                this.path = path;
            }
            public void add(string t){
                this.logs.Enqueue("[" + currTime() +"] " + t);
            }
            public void saveNow(){
                if(this.logs.Count > 0){
                    // Get from queue
                    string err = (string) this.logs.Dequeue();
                    // Save to logs
                    saveToFile(err, this.path);
                }
            }
            public bool saveToFile(string text, string path)
            {
                try{
                    // string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    // text = text + Environment.NewLine;
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(text);
                        sw.Close();
                    }
                }catch(Exception e){
                    // return to queue
                    this.logs.Enqueue(text + "[SAVE_ERR]");
                    return false;
                }
                return true;
            }
            public String currTime(){
                DateTime d = DateTime.UtcNow.ToLocalTime();
                return d.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }
    }
