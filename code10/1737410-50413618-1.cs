    private JsonResult GetProcesedXml()
    {
         JObject json = null;
         Stream request = Request.InputStream;
         using (StreamReader sr = new StreamReader(stream))
         {
               stream.Seek(0, System.IO.SeekOrigin.Begin);
               json = JObject.Parse(sr.ReadToEnd());
         }
         string xmlSigninigResult = json["resultXml"].ToString();
         // rest of the method
    }
