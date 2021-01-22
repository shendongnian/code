    private static string UploadFilesToRemoteUrl(string url, IList<byte[]> files, NameValueCollection nvc) {
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            var postQueue = new ByteArrayCustomQueue();
            var formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
            foreach (string key in nvc.Keys) {
                var formitem = string.Format(formdataTemplate, key, nvc[key]);
                var formitembytes = Encoding.UTF8.GetBytes(formitem);
                postQueue.Write(formitembytes);
            }
            var headerTemplate = "\r\n--" + boundary + "\r\n" +
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + 
                "Content-Type: application/zip\r\n\r\n";
            var i = 0;
            foreach (var file in files) {
                var header = string.Format(headerTemplate, "file" + i, "file" + i + ".zip");
                var headerbytes = Encoding.UTF8.GetBytes(header);
                postQueue.Write(headerbytes);
                postQueue.Write(file);
                i++;
            }
            postQueue.Write(Encoding.UTF8.GetBytes("\r\n--" + boundary + "--"));
            request.ContentLength = postQueue.Length;
            using (var requestStream = request.GetRequestStream()) {
                postQueue.CopyToStream(requestStream);
                requestStream.Close();
            }
            var webResponse2 = request.GetResponse();
            using (var stream2 = webResponse2.GetResponseStream())
            using (var reader2 = new StreamReader(stream2)) {
                var res =  reader2.ReadToEnd();
                webResponse2.Close();
                return res;
            }
        }
    public class ByteArrayCustomQueue {
        private LinkedList<byte[]> arrays = new LinkedList<byte[]>();
        /// <summary>
        /// Writes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Write(byte[] data) {
            arrays.AddLast(data);
        }
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length { get { return arrays.Sum(x => x.Length); } }
        /// <summary>
        /// Copies to stream.
        /// </summary>
        /// <param name="requestStream">The request stream.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CopyToStream(Stream requestStream) {
            foreach (var array in arrays) {
                requestStream.Write(array, 0, array.Length);
            }
        }
    }
