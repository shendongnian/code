    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Web;
    namespace WebApplication1
    {
        public class CssHandler : IHttpHandler
        {
            public bool IsReusable { get { return true; } }
    
            public void ProcessRequest(HttpContext context)
            {
                string[] cssFiles = context.Request.QueryString["cssfiles"].Split(',');
    
                List<string> files = new List<string>();
                StringBuilder response = new StringBuilder();
                foreach (string cssFile in cssFiles)
                {
                    if (!cssFile.EndsWith(".css", StringComparison.OrdinalIgnoreCase))
                    {
                        //log custom exception
                        context.Response.StatusCode = 403;
                        return;
                    }
    
                    try
                    {
                        string filePath = context.Server.MapPath(cssFile);
                        string css = File.ReadAllText(filePath);
                        string compressedCss = Yahoo.Yui.Compressor.CssCompressor.Compress(css);
                        response.Append(compressedCss);
                    }
                    catch (Exception ex)
                    {
                        //log exception
                        context.Response.StatusCode = 500;
                        return;
                    }
                }
    
                context.Response.Write(response.ToString());
    
                string version = "1.0"; //your dynamic version number 
    
                context.Response.ContentType = "text/css";
                context.Response.AddFileDependencies(files.ToArray());
                HttpCachePolicy cache = context.Response.Cache;
                cache.SetCacheability(HttpCacheability.Public);
                cache.VaryByParams["cssfiles"] = true;
                cache.SetETag(version);
                cache.SetLastModifiedFromFileDependencies();
                cache.SetMaxAge(TimeSpan.FromDays(14));
                cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            }
        }
    }
