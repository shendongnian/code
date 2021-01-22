     /// <summary>
        /// Returns XML string for a specific query
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Account"></param>
        /// <param name="Folder"></param>
        /// <returns></returns>
        private string ProcessRequest(string Query, string Account, string Folder) {
    
         System.Net.WebRequest req = WebRequest.Create("http://" + MailServer + "/exchange/" + Account + "/" + Folder);
          req.Headers.Add("Depth", "1");
          req.Headers.Add("Brief", "t");
          req.Credentials = ncCurrent;
    
          Byte[] bytes  = System.Text.Encoding.ASCII.GetBytes(Query);
          req.ContentType = "text/xml";
          req.ContentLength = bytes.Length;
          req.Method = "SEARCH";
    
          System.IO.Stream oStreamOut = req.GetRequestStream();
          oStreamOut.Write(bytes, 0, bytes.Length);
          oStreamOut.Close();
    
          WebResponse rsp = req.GetResponse();
          System.IO.Stream oStreamIn = rsp.GetResponseStream();
          System.IO.StreamReader oStreamRead = new System.IO.StreamReader(oStreamIn);
          return oStreamRead.ReadToEnd();
    }
