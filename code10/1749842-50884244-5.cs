    public class MyObj : IDisposable
    {
        public static MyObj Create()
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                stream = File.Open("myFile.txt", FileMode.Create);
                reader = new StreamReader(stream);
                return new MyObj(reader);
            }
            catch
            {
                reader?.Dispose();
                stream?.Dispose();
                throw;
            }
        }
        private readonly StreamReader _reader;
        private MyObj(StreamReader reader)
        {
            _reader = reader;
        }
        public string ReadMessage()
        {
            return "the message: " + _reader.ReadToEnd();
        }
        
        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
