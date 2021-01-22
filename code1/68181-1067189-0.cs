        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Services;
        using System.IO;
        namespace TestWeb
        {
            /// <summary>
            /// Summary description for $codebehindclassname$
            /// </summary>
            [WebService(Namespace = "http://tempuri.org/")]
            [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
            public class ServeImage : IHttpHandler
            {
                private static IDictionary<string, string> contentTypes = 
                                    new Dictionary<string, string>();
                static ServeImage()
                {
                        contentTypes.Add("pdf","Content-type: application/pdf");
                        contentTypes.Add("gif","image/gif");
                        contentTypes.Add("png","image/x-png");
                        contentTypes.Add("jpg","image/jpeg");
                        contentTypes.Add("jpeg","image/jpeg");
                        contentTypes.Add("jpe","image/jpeg");
                        contentTypes.Add("tiff","image/tiff");
                        contentTypes.Add("tif","image/tiff");
                        contentTypes.Add("rtf","application/rtf");
                        contentTypes.Add("doc","application/msword");
                        contentTypes.Add("zip","application/zip");
                        contentTypes.Add("rar","applicatin/rar");
                        contentTypes.Add("ppz","application/mspowerpoint");
                        contentTypes.Add("ppt","applicaiton/vnd.ms-mspowerpoint");
                        contentTypes.Add("pps","applicaiton/vnd.ms-mspowerpoint");
                        contentTypes.Add("pot","applicaiton/vnd.ms-mspowerpoint");
                        contentTypes.Add("xls","application/x-msexcel");
                        contentTypes.Add("xlsx","application/x-msexcel");
                }
                public void ProcessRequest(HttpContext context)
                {
                    ServeFile(context);
                }
                private void ServeFile(HttpContext context)
                {
                    string serverAdd = context.Server.MapPath("/");
                    string file = context.Request.QueryString["img"] + "";
                    //suppose your url is http://host/ServeImage.isr?img=pic.png
                    //OR http://host/ServeImage.isr?img=images/somepic.png
                    file = file.Replace("/", "\\");
                    //as MapPath will return path separated with \
                    
                    if (File.Exists(serverAdd + file))
                    {
                        FileInfo fi = new FileInfo(serverAdd + file);
                        FileStream fs=fi.OpenRead();
                        byte[] ar = new byte[fs.Length];
                        int len=1024;
                        int j=0;
                        int i = fs.Read(ar, 0, len);                
                        while (i > 0)
                        {
                            j += Math.Min(len, i);
                            if (j + len > ar.Length)
                                len = ar.Length-j;
                            
                            i = fs.Read(ar, j, len);
                        }
                        HttpResponse response = context.Response;
                        string ext = Path.GetExtension(file);
                        response.Clear();
                        if (contentTypes.ContainsKey(ext))
                            response.AppendHeader("contentType", 
                                          contentTypes[ext]);
                        response.Buffer = true;
                        response.BinaryWrite(ar);
                        response.Flush();
                        response.End();
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
        }
