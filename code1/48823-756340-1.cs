    public class DownloadResult : ActionResult
    {
        public DownloadResult()
        {
        }
    
        public DownloadResult(string virtualPath)
        {
            VirtualPath = virtualPath;
        }
    
        public string VirtualPath { get; set; }
    
        public string FileDownloadName { get; set; }
    
        public override void ExecuteResult(ControllerContext context)
        {
            if (!String.IsNullOrEmpty(FileDownloadName))
            {
                context.HttpContext.Response.AddHeader("Content-type",
                                                       "application/force-download");
                context.HttpContext.Response.AddHeader("Content-disposition",
                                                       "attachment; filename=\"" + FileDownloadName + "\"");
            }
    
            string filePath = context.HttpContext.Server.MapPath(VirtualPath);
            context.HttpContext.Response.TransmitFile(filePath);
        }
    }
