    public class GenerateImage : IHttpHandler
    {
        /// <summary>
        /// Shortcut to the database controller.  Instantiated immediately
        /// since the ProcessRequest method uses it.
        /// </summary>
        private static readonly IDataModelDatabaseController controller =
            DataModelDatabaseControllerFactory.Controller;
    
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler
        /// that implements the <see cref="T:System.Web.IHttpHandler"/>
        /// interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/>
        /// object that provides references to the intrinsic server objects
        /// (for example, Request, Response, Session, and Server) used to
        /// service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            if (controller == null)
            {
                return;
            }
    
            IDataModelDescriptor desc = controller.GetDataModelDescriptor(
                new Guid(context.Request.QueryString["dataModel"]));
            IDataModelField imageField =
                desc.Fields[context.Request.QueryString["imageField"]];
            IDatabaseSelectQuery query = controller.CreateQuery();
            string[] keys = context.Request.QueryString["key"].Split(',');
            string showThumb = context.Request.QueryString["showThumbnail"];
            bool showThumbnail = showThumb != null;
    
            query.AssignBaseTable(desc);
            query.AddColumn(imageField, false);
            for (int i = 0; i < desc.KeyFields.Count; i++)
            {
                query.AddCompareValue(
                    desc.KeyFields[i],
                    keys[i],
                    DatabaseOperator.Equal);
            }
    
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "image/jpeg";
            context.Response.Expires = -1;
    
            byte[] originalImage = (byte[])controller.ExecuteScalar(query);
    
            if (showThumbnail)
            {
                int scalePixels;
    
                if (!int.TryParse(showThumb, out scalePixels))
                {
                    scalePixels = 100;
                }
    
                using (Stream stream = new MemoryStream(originalImage))
                using (Image img = Image.FromStream(stream))
                {
                    double multiplier;
    
                    if ((img.Width <= scalePixels)
                        && (img.Height <= scalePixels))
                    {
                        context.Response.BinaryWrite(originalImage);
                        return;
                    }
                    else if (img.Height < img.Width)
                    {
                        multiplier = (double)img.Width / (double)scalePixels;
                    }
                    else
                    {
                        multiplier = (double)img.Height / (double)scalePixels;
                    }
    
                    using (Bitmap finalImg = new Bitmap(
                        img,
                        (int)(img.Width / multiplier),
                        (int)(img.Height / multiplier)))
                    using (Graphics g = Graphics.FromImage(finalImg))
                    {
                        g.InterpolationMode =
                            InterpolationMode.HighQualityBicubic;
                        finalImg.Save(
                            context.Response.OutputStream,
                            ImageFormat.Jpeg);
                    }
                }
            }
            else
            {
                context.Response.BinaryWrite(originalImage);
            }
        }
    
        /// <summary>
        /// Gets a value indicating whether another request can use the
        /// <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/>
        /// instance is reusable; otherwise, false.
        /// </returns>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
