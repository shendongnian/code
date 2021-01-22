    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                BackgroundWorker b = new BackgroundWorker();
                b.DoWork += new DoWorkEventHandler(b_DoWork);
                b.RunWorkerCompleted += new RunWorkerCompletedEventHandler(b_RunWorkerCompleted);
                b.RunWorkerAsync("My Query");
    
                while(b.IsBusy)
                {
                    
                }
                Console.ReadLine();
            }
    
            static void b_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if(e.Result is string)
                {
                    Console.WriteLine((string)e.Result);
                }
            }
    
            static void b_DoWork(object sender, DoWorkEventArgs e)
            {
                if (e.Argument is string)
                {
                    string post = "q=" + (string) e.Argument;
                    WebRequest request = WebRequest.Create("http://test.com");
                    request.Timeout = 20000;
                    request.Method = "POST";
                    byte[] bytes = Encoding.UTF8.GetBytes(post);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    WebResponse response = request.GetResponse();
                    requestStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(requestStream);
                    string ret = reader.ReadToEnd();
                    reader.Close();
                    requestStream.Close();
                    response.Close();
                    e.Result = ret;
                }
            }
        }
    }
