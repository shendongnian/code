    using System;
    using System.IO;
    using System.Net;
    namespace myRSSVideoReader
    {
    public static class FlvMetadataReader
    {
        static string onMetaData = "";
        static string bytesToFile = "";
        /// <summary>
        /// Reads the meta information (if present) in an FLV
        /// </summary>
        /// <param name="uri">The uri to the FLV file</returns>
        public static MediaMetadataInfo GetMetadataInfo(string uri)
        {
            //needed for the file name only
            Uri newUri = new Uri(uri);
            Stream strm = null;
            StreamReader MyReader = null;
            bool hasMetaData = false;
            double duration = 0;
            double width = 0;
            double height = 0;
            double videoDataRate = 0;
            double audioDataRate = 0;
            double frameRate = 0;
            DateTime creationDate = DateTime.MinValue;
            int range = 800;
            try
            {
                //byte[] result;
                byte[] buffer = new byte[range];
                strm = GetURLStream(uri, range);
                if (strm != null)
                {
                    using (MemoryStream fileStream = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            count = strm.Read(buffer, 0, buffer.Length);
                            fileStream.Write(buffer, 0, count);
                        }
                        while (count != 0);
                        // read where "onMetaData" in flash, this indicates we've got maetadata
                        byte[] bytes = new byte[1000];
                        fileStream.Seek(27, SeekOrigin.Begin);
                        int result = fileStream.Read(bytes, 0, 1000);
                        // if "onMetaData" exists then proceed to read the attributes
                        bytesToFile = ByteArrayToString(bytes);
                        onMetaData = bytesToFile.Substring(0, 10);
                        if (onMetaData == "onMetaData")
                        {
                            hasMetaData = true;
                            duration = GetNextDouble(bytes, bytesToFile.IndexOf("duration") + 9, 8);
                            duration = Math.Round(duration);
                            width = GetNextDouble(bytes, bytesToFile.IndexOf("width") + 6, 8);
                            height = GetNextDouble(bytes, bytesToFile.IndexOf("height") + 7, 8);
                            videoDataRate = GetNextDouble(bytes, bytesToFile.IndexOf("videodatarate") + 14, 8);
                            audioDataRate = GetNextDouble(bytes, bytesToFile.IndexOf("audiodatarate") + 14, 8);
                            frameRate = GetNextDouble(bytes, bytesToFile.IndexOf("framerate") + 10, 8);
                        }
                        fileStream.Close();
                        fileStream.Dispose();
                    }                    
                }
            }
            catch {}
            finally
            {
                // do some cleanup
                if (MyReader != null)                
                    MyReader.Close();
                
                if (strm != null)                
                    strm.Close();                
            } 
            string filename = Path.GetFileName(newUri.AbsoluteUri);
            return new MediaMetadataInfo(hasMetaData, filename, duration, width, height, videoDataRate, audioDataRate, frameRate, creationDate);
        }
        /* ------------------------------------------------------------- */
        private static Stream GetURLStream(string strURL, int range)
        {
            WebRequest req;
            WebResponse res = null;
            Stream respStream;
            try
            {
                req = WebRequest.Create(strURL);
                ((HttpWebRequest)req).UserAgent = "myRSSVideoReader/1.0.0.12 (compatible; http://www.myrssvideoreader.com; Your RSS feeds need duration value;)";
                ((HttpWebRequest)req).AddRange(0, range * 2); 
                res = req.GetResponse();
                respStream = res.GetResponseStream();
                return respStream;
            }
            catch (Exception)
            {
                res.Close();
                return null;
            }
        }
        /* ------------------------------------------------------------- */
        private static Double GetNextDouble(Byte[] b, int offset, int length)
        {
            MemoryStream ms = new MemoryStream(b);
            // move the desired number of places in the array
            ms.Seek(offset, SeekOrigin.Current);
            // create byte array
            byte[] bytes = new byte[length];
            // read bytes
            int result = ms.Read(bytes, 0, length);
            // convert to double (all flass values are written in reverse order)
            return ByteArrayToDouble(bytes, true);
        }
        /* ------------------------------------------------------------- */
        private static String ByteArrayToString(byte[] bytes)
        {
            string byteString = string.Empty;
            foreach (byte b in bytes)
            {
                byteString += Convert.ToChar(b).ToString();
            }
            return byteString;
        }
        /* ------------------------------------------------------------- */
        private static Double ByteArrayToDouble(byte[] bytes, bool readInReverse)
        {
            if (bytes.Length != 8)
                throw new Exception("bytes must be exactly 8 in Length");
            if (readInReverse)
                Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
    }
