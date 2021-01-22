      HttpResponseMessage result = null;
           var httpRequest = System.Web.HttpContext.Current.Request;
           HttpFileCollection uploadFiles = httpRequest.Files;
           var docfiles = new List<string>();
           if (httpRequest.Files.Count > 0)
           {
            
             int i;
             for (i = 0; i < uploadFiles.Count; i++)
             {
                 HttpPostedFile postedFile = uploadFiles[i];
                 var filePath = @"C:/inetpub/wwwroot/test1/reports/" + postedFile.FileName;
                 postedFile.SaveAs(filePath);
                 docfiles.Add(filePath);
             
             }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
           }
           else 
           {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
           }
            
             return result;
        }
        
