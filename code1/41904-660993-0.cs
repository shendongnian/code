     public Image GetDilbert()
     {
         var dilbertUrl = new Uri(@"http://dilbert.com");
         var request    = WebRequest.CreateDefault(dilbertUrl);    
         string html;   
         Image  returnValue;
         var result = (IAsyncResult) request.BeginGetResponse(asynchResult => 
         {  
              //inside AsynchCallBack method for request.BeginGetResponse()
              var response = (HttpWebResponse) request.EndGetResponse((asynchResult ); 
                   
              string html;  
              using (var receiveStream = webResponse.GetResponseStream())
              using (var readStream    = new StreamReader(receiveStream, Encoding.UTF8))
              {
                 html = readStream.ReadToEnd();
              }
              var regex = new Regex(@"dyn/str_strip/[0-9/]+/[0-9]*\.strip\.gif");
              var match = regex.Match(html);
              
              if (match.Success) 
              { 
                  var groups = match.Groups;
                  var s      = (groups.Count > 0) ? groups[groups.Count-1].ToString():match.Value;
                  var imageRequest = WebRequest.CreateDefault(new Uri(dilbertUrl, s));
                  var imageResult = imageRequest.BeginGetResponse(ar => 
                  {  //inside AsynchCallBack method for imageRequest.BeginGetResponse() 
                     var imageResponse = (HttpWebResponse) imageRequest.EndGetResponse(ar);
                     using (var imageStream = imageResponse.GetResponseStream())
                     { 
                        returnValue = (Image) Image.FromStream(imageStream, true, true ).Clone();
                     }               
                  }, new object() /*state*/))
            
                  imageResult.WaitOne();
              }         
         }, new object() /* state */);
         result.WaitOne();  
         return returnValue;      
     }
