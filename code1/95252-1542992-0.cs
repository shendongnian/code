    public sealed class Uploader
    {
        public const int CHUNK_SIZE = 1024; // 1 KB
        public void Upload(string url, string filename, Stream streamToUpload, Action<int> progress)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            string boundary = string.Format("---------------------{0}", DateTime.Now.Ticks.ToString("x"));
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            request.KeepAlive = true;
            using (var requestStream = request.GetRequestStream())
            {
                var header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n", boundary, filename);
                var headerBytes = Encoding.ASCII.GetBytes(header);
                requestStream.Write(headerBytes, 0, headerBytes.Length);
                byte[] buffer = new byte[CHUNK_SIZE];
                int bytesRead;
                long total = streamToUpload.Length;
                long totalBytesRead = 0;
                while ((bytesRead = streamToUpload.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                    progress((int)(100 * totalBytesRead / total));
                    byte[] actual = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
                    requestStream.Write(actual, 0, actual.Length);
                }
            }
            using (var response = request.GetResponse()) { }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:2141/Default.aspx";
            var filename = "1.dat";
            var uploader = new Uploader();
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                uploader.Upload(url, filename, fileStream, progress => Console.WriteLine("{0}% of \"{1}\" uploaded to {2}", progress, filename, url));
            }
        }
    }
