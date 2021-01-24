        public static string ReadRequestBody(this HttpRequest request, Encoding encoding)
        {
            var body = "";
            request.EnableRewind();
            if (request.ContentLength == null ||
                !(request.ContentLength > 0) ||
                !request.Body.CanSeek)
            {
                return body;
            }
            request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(request.Body, encoding, true, 1024, true))
            {
                body = reader.ReadToEnd();
            }
            //Reset the stream so data is not lost
            request.Body.Position = 0;
            return body;
        }
