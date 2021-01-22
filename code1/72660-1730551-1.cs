     public class ImageHttpHandler:IHttpHandler
        {
            private string _fileName;
    
            public ImageHttpHandler(string filename)
            {
                _fileName = filename;
            }
    
            #region IHttpHandler Members
    
            public bool IsReusable
            {
                get { throw new NotImplementedException(); }
            }
            
            public void ProcessRequest(HttpContext context)
            {
                if (string.IsNullOrEmpty(_fileName))
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    context.Response.End();
                }
                else
                {
                    context.Response.Clear();
                    context.Response.ContentType = GetContentType(context.Request.Url.ToString());
    
                    // find physical path to image here.  
                    string filepath = context.Server.MapPath("~/images/" + _fileName);
    
                    context.Response.WriteFile(filepath);
                    context.Response.End();
                }
                
            }
    
            private static string GetContentType(String path)
            {
                switch (Path.GetExtension(path))
                {
                    case ".bmp": return "Image/bmp";
                    case ".gif": return "Image/gif";
                    case ".jpg": return "Image/jpeg";
                    case ".png": return "Image/png";
                    default: break;
                }
                return "";
            }
    
            #endregion
        }
