    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace app
    {
        class Worker
        {
    
    	    public delegate void OnRetryDelegate(int id);
    
            public event OnRetryDelegate OnRetry;
    		
            public delegate void OnRespnseDelegate(Worker sender, bool success);
    
            public event OnRespnseDelegate OnRespnse;
    
            public Worker()
            {
                Id = IdProvider.GetNewId();
                thread = new Thread(new ThreadStart(ExecuteAsync));
                thread.Start();
            }
    
            private readonly Thread thread;
            public string Number;
            public bool Idle { get; set; }
            public bool ShutDown { get; set; }
            public bool Started { get; set; }
            public int Id { get; private set; }
    		public PostData { get; set; }
    		
            public void Start(string postData)
            {
    			PostData = postData;
                Idle = true;
                Started = true;
            }
    
            private void ExecuteAsync()
            {
                while (!ShutDown)
                {
                    Thread.Sleep(1500);
                    if (Idle)
                    {
                        Idle = false;
                        if (Number == "terminate")
                        {
                            ShutDown = true;
                            return;
                        }
    
                        try
                        {
                            var request = (HttpWebRequest) WebRequest.Create("https://example.com");
                            var data = Encoding.ASCII.GetBytes(postData);
                            Debug.Print("send:  " + postData);
                            request.Method = "POST";
                            request.ContentType = "application/x-www-form-urlencoded";
                            request.ContentLength = data.Length;
                            using (var stream = request.GetRequestStream())
                            {
                                stream.Write(data, 0, data.Length);
                            }
                            var response = (HttpWebResponse) request.GetResponse();
                            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            Debug.Print(responseString);
                            if (responseString.Contains("something"))
                                OnRespnse?.Invoke(this, true);
                        }
                        catch (Exception)
                        {
                            OnRetry?.Invoke(Id);
                        }
    
                        OnRespnse?.Invoke(this, false);
                    }
                }
            }
        }
    }
