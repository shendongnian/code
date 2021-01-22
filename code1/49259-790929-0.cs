    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    
    namespace ConnectionTest
    {
        public class RequestCounter
        {
            public int Counter = 0;
            public void Increment()
            {
                Interlocked.Increment(ref Counter);
            }
        }
    
        public class RequestThread
        {
            public AutoResetEvent AsyncWaitHandle { get; private set; }
            public RequestCounter RequestCounter;
            public String Url;
            public HttpWebRequest Request;
            public HttpWebResponse Response;
    
            public RequestThread(AutoResetEvent r, String u, RequestCounter rc)
            {
                Url = u;
                AsyncWaitHandle = r;
                RequestCounter = rc;
            }
    
            public void Close()
            {
                if (Response != null)
                    Response.Close();
                
                if (Request != null)
                    Request.Abort();
            }
        }
    
        public class ConnectionTest
        {
            static void Main()
            {
                string url = "http://www.google.com/";
                int max = GetMaxConnections(25, url);
                Console.WriteLine(String.Format("{0} Max Connections to {1}",max,url));
                Console.ReadLine();
            }
    
            private static int GetMaxConnections(int maxThreads, string url)
            {
                RequestCounter requestCounter = new RequestCounter();
    
                List<RequestThread> threadState = new List<RequestThread>();
                for (int i = 0; i < maxThreads; i++)
                    threadState.Add(new RequestThread(new AutoResetEvent(false), url, requestCounter));
    
                List<Thread> threads = new List<Thread>();
                foreach (RequestThread state in threadState)
                {
                    Thread t = new Thread(StartRequest);
                    t.Start(state);
                    threads.Add(t);
                }
    
                WaitHandle[] handles = (from state in threadState select state.AsyncWaitHandle).ToArray();
                WaitHandle.WaitAll(handles, 5000); // waits seconds
    
                foreach (Thread t in threads)
                    t.Abort();
    
                foreach(RequestThread rs in threadState)
                    rs.Close();
    
                return requestCounter.Counter;
            }
    
            public static void StartRequest(object rt)
            {
                RequestThread state = (RequestThread) rt;
                try
                {
                    state.Request = (HttpWebRequest)WebRequest.Create(state.Url);
                    state.Request.ReadWriteTimeout = 4000; //Waits 4 seconds
    
                    state.Response = (HttpWebResponse)state.Request.GetResponse();
                    if (state.Response.StatusDescription.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                        state.RequestCounter.Increment();
    
                    //Do not close, or you will free a connection. Close Later
                    //response.Close(); 
                }
                catch (WebException e)
                {
                    //Console.WriteLine("Message:{0}", e.Message);
                    state.Close();
                }
                catch (ThreadAbortException e)
                {
                    //Console.WriteLine("Thread Aborted");
                    state.Close();
                }
                catch(Exception e)
                {
                    //Console.WriteLine("Real Exception");    
                    state.Close();
                }
                finally
                {
                    state.AsyncWaitHandle.Set();
                }
            }
        }
    }
