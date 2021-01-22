    DataTable myDataTable = new DataTable();
    
    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://someplace/somefile.xml");
    myRequest.Method = "GET";
    
    WebResponse myResponse;
    try
    {
       myResponse = myRequest.GetResponse();
    
       using (Stream responseStream = myResponse.GetResponseStream())
       { 
          myDataTable.ReadXml(responseStream);
       }
    }
    catch
    { }
