    using (var stream = new MemoryStream())
         {
            HttpContextBase context = (HttpContextBase)actionContext.Request.Properties["MS_HttpContext"];
            if(context.Request.Contentlength > 0)
            {
                context.Request.InputStream.Seek(0, SeekOrigin.Begin);
                context.Request.InputStream.CopyTo(stream);
                requestBody = Encoding.UTF8.GetString(stream.ToArray());
            }
         }
