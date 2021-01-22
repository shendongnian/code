    HttpWebRequest request;
    HttpWebResponse response = null;
    
    try
    {
    
       FileStream fs;
       Stream s;
       byte[] read;
       int count;
    
       read = new byte[256];
    
       request = (HttpWebRequest)WebRequest.Create(remoteFilename);
       request.Timeout = 30000;
       request.AllowWriteStreamBuffering = false;
    
       response = (HttpWebResponse)request.GetResponse();
       s = response.GetResponseStream();  
    
       fs = new FileStream(localFilename, FileMode.Create);   
       while((count = s.Read(read, 0, read.Length))> 0)
       {
          fs.Write(read, 0, count);
          count = s.Read(read, 0, read.Length);
       }
    
       fs.Close();
       s.Close();
    }
    catch (System.Net.WebException)
    {
        //....
    }finally
    {
       //Close Response
       if (response != null)
          response.Close();
    }
