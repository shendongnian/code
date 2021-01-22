    public class FileHandler : IHttpHandler
    	{
    		public void ProcessRequest(HttpContext context)
    		{
    			if (context.Request["file"] != null)
    			{
    				try
    				{
    					string file = context.Server.MapPath("~/files/" + context.Request["file"].ToString());
    					FileInfo fi = new FileInfo(file);
    					if (fi.Exists)
    					{
    						context.Response.ClearContent();
    						context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fi.Name);
    						context.Response.AddHeader("Content-Length", fi.Length.ToString());
    						string fExtn = "video/avi";
    						context.Response.ContentType = fExtn;
    						context.Response.TransmitFile(fi.FullName);
    						context.Response.End();
    					}
    				}
    				catch (Exception ex)
    				{
    					Trace.WriteLine(ex.Message);
    				}
    			}
    		}
    
    		public bool IsReusable
    		{
    			get { return true; }
    		}
    	}
