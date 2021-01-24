    public string UploadVideoFile(string URL, byte[] VideoFileData)
        {
          string Response = null;
          HttpWebRequest WebReq = null;
          HttpWebResponse WebRes = null;
          StreamReader StreamResponseReader = null;
          Stream requestStream = null;
          try
          {
            WebReq = (HttpWebRequest)WebRequest.Create(URL);
            WebReq.Method = "POST";
            WebReq.Accept = "*/*";
            WebReq.Timeout = 50000;
            WebReq.KeepAlive = false;
            WebReq.AllowAutoRedirect = false;
            WebReq.AllowWriteStreamBuffering = true;
            WebReq.ContentType = "binary/octet-stream";
            WebReq.ContentLength = VideoFileData.Length;
            
    
            requestStream = WebReq.GetRequestStream();
            requestStream.Write(VideoFileData, 0, VideoFileData.Length);
            
            requestStream.Close();
            
            WebRes = (HttpWebResponse)WebReq.GetResponse();
            StreamResponseReader = new StreamReader(WebRes.GetResponseStream(), Encoding.UTF8);
            Response = StreamResponseReader.ReadToEnd();
          }
          catch
          {
            throw;
          }
          finally
          {
            if (WebReq != null)
            {
              WebReq.Abort();
              WebReq = null;
            }
            if (WebRes != null)
            {
              WebRes.Close();
              WebRes = null;
            }
            if (StreamResponseReader != null)
            {
              StreamResponseReader.Close();
              StreamResponseReader = null;
            }
            if (requestStream != null)
            {
              requestStream = null;
            }
          }
    
    
          return Response;
        }
