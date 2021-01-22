    [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class receiver : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                string filename = context.Request.QueryString["filename"].ToString();
    
                using (FileStream fs = File.Create(context.Server.MapPath("~/images/" + filename)))
                {
                    SaveFile(context.Request.InputStream, fs);
                }
            }
    
            private void SaveFile(Stream stream, FileStream fs)
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                }
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
    
    
        }
