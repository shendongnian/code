    HttpWebRequest oRequest = null;
    oRequest = (HttpWebRequest)HttpWebRequest.Create("http://you.url.here");
    oRequest.ContentType = "multipart/form-data; boundary=" + PostData.boundary;
    oRequest.Method = "POST";
    PostData pData = new PostData();
    Encoding encoding = Encoding.UTF8;
    Stream oStream = null;
    /* ... set the parameters, read files, etc. IE:
       pData.Params.Add(new PostDataParam("email", "example@example.com", PostDataParamType.Field));
       pData.Params.Add(new PostDataParam("fileupload", "filename.txt", "filecontents" PostDataParamType.File));
    */
    byte[] buffer = encoding.GetBytes(pData.GetPostData());
    oRequest.ContentLength = buffer.Length;
    oStream = oRequest.GetRequestStream();
    oStream.Write(buffer, 0, buffer.Length);
    oStream.Close();
    HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse();
 
