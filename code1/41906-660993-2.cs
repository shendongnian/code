     public Image GetDilbert()
     {
         var   dilbertUrl  = new Uri(@"http://dilbert.com");
         var   request     = WebRequest.CreateDefault(dilbertUrl);
         var   webHandle   = new ManualResetEvent(false /* nonsignaled */);
         Image returnValue = null;
         request.BeginGetResponse(ar => 
         {  
              //inside AsynchCallBack method for request.BeginGetResponse()
              var response = (HttpWebResponse) request.EndGetResponse(ar); 
                   
              string html;  
              using (var receiveStream = response.GetResponseStream())
              using (var readStream    = new StreamReader(  receiveStream
                                                          , Encoding.UTF8))
              {
                 html = readStream.ReadToEnd();
              }
              var re=new Regex(@"dyn/str_strip/[0-9/]+/[0-9]*\.strip\.gif");
              var match=re.Match(html);
              
              var imgHandle = new ManualResetEvent(true /* signaled  */);
              
              if (match.Success) 
              {   
                  imgHandle.Reset();              
                 
                  var groups = match.Groups;
                  var s = (groups.Count>0) ?groups[groups.Count-1].ToString()
                                           :match.Value;
                  var _uri   = new Uri(dilbertUrl, s);
                  var imgReq = WebRequest.CreateDefault(_uri);
                  imgReq.BeginGetResponse(ar2 => 
                  {  var imageRsp= (HttpWebResponse)imgReq.EndGetResponse(ar2);
                     using (var imgStream=imageRsp.GetResponseStream())
                     { 
                        var im=(Image)Image.FromStream(imgStream,true,true);
                        returnValue = (Image) im.Clone();
                     }    
                     
                     imgHandle.Set();           
                  }, new object() /*state*/);
              }      
              
              imgHandle.WaitOne();
              webHandle.Set();  
         }, new object() /* state */);
         webHandle.WaitOne();  
         return returnValue;      
     }
