    class Program
        {
            private static AutoResetEvent done = new AutoResetEvent(false);
            private static AsyncCallback _callbackReadStream;
            private static AsyncCallback _callbackWriteFile;
    
            static void Main(string[] args)
            {
            try
            {
                _callbackReadStream = new AsyncCallback(CallbackReadStream);
                _callbackWriteFile = new AsyncCallback(CallbackWriteFile);
                string url = "http://...";
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.BeginGetResponse(new AsyncCallback(
                    CallbackGetResponse), request);
                done.WaitOne();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        private class State
        {
            public Stream ReponseStream { get; set; }
            public HashAlgorithm Hash { get; set; }
            public Stream FileStream { get; set; }
            private byte[] _buffer = new byte[16379];
            public byte[] Buffer { get { return _buffer; } }
            public int ReadBytes { get; set; }
            public long FileLength {get;set;}
        }
        static void CallbackGetResponse(IAsyncResult ar)
        {
            try
            {
                WebRequest request = (WebRequest)ar.AsyncState;
                WebResponse response = request.EndGetResponse(ar);
                State s = new State();
                s.ReponseStream = response.GetResponseStream();
                s.FileStream = new FileStream("download.out"
                    , FileMode.Create
                    , FileAccess.Write
                    , FileShare.None);
                s.Hash = HashAlgorithm.Create("MD5");
                s.ReponseStream.BeginRead(
                    s.Buffer
                    , 0
                    , s.Buffer.Length
                    , _callbackReadStream
                    , s); 
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                done.Set();
            }
        }
        private static void CallbackReadStream(IAsyncResult ar)
        {
            try
            {
                State s = (State)ar.AsyncState;
                s.ReadBytes = s.ReponseStream.EndRead(ar);
                s.Hash.ComputeHash(s.Buffer, 0, s.ReadBytes);
                s.FileStream.BeginWrite(
                    s.Buffer
                    , 0
                    , s.ReadBytes
                    , _callbackWriteFile
                    , s);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                done.Set();
            }
        }
        static private void CallbackWriteFile(IAsyncResult ar)
        {
            try
            {
                State s = (State)ar.AsyncState;
                s.FileStream.EndWrite(ar);
                s.FileLength += s.ReadBytes;
                if (0 != s.ReadBytes)
                {
                    s.ReponseStream.BeginRead(
                        s.Buffer
                        , 0
                        , s.Buffer.Length
                        , _callbackReadStream
                        , s);
                }
                else
                {
                    Console.Out.Write("Downloaded {0} bytes. Hash(base64):{1}",
                        s.FileLength, Convert.ToBase64String(s.Hash.Hash));
                    done.Set();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                done.Set();
            }
                
        }
    }
