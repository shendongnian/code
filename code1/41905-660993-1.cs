     public Image GetDilbert()
     {
         var   dilbertUrl  = new Uri(@"http://dilbert.com");
         var   request     = WebRequest.CreateDefault(dilbertUrl);    
         Image returnValue = null;
         var result = (IAsyncResult) request.BeginGetResponse(ar => 
         {  
              //inside AsynchCallBack method for request.BeginGetResponse()
              var response = (HttpWebResponse) request.EndGetResponse(ar); 
                   
              string html;  
              using (var receiveStream = webResponse.GetResponseStream())
              using (var readStream    = new StreamReader(  receiveStream
                                                          , Encoding.UTF8))
              {
                 html = readStream.ReadToEnd();
              }
              var re=new Regex(@"dyn/str_strip/[0-9/]+/[0-9]*\.strip\.gif");
              var match=re.Match(html);
              
              if (match.Success) 
              { 
                  var groups = match.Groups;
                  var s = (groups.Count>0) ? groups[groups.Count-1].ToString()
                                           : match.Value;
                  var _uri   = new Uri(dilbertUrl, s);
                  var imgReq = WebRequest.CreateDefault(_uri);
                  var imageResult = imgReq.BeginGetResponse(ar2 => 
                  {  var imageRsp= (HttpWebResponse)imgReq.EndGetResponse(ar2);
                     using (var imgStream = imageRsp.GetResponseStream())
                     { 
                        var im = (Image)Image.FromStream(imgStream,true,true);
                        var returnValue = im.Clone();
                     }               
                  }, new object() /*state*/));
            
                  imageResult.WaitOne();
              }         
         }, new object() /* state */);
         result.WaitOne();  
         return returnValue;      
     }
