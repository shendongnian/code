    using System;
    using System.Web;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Web.Caching;
    
    public partial class global : System.Web.HttpApplication {
    	protected void Application_Start() {
    		RemoveTemporaryFiles();
    		RemoveTemporaryFilesSchedule();
    	}
    
    	public void RemoveTemporaryFiles() {
    		string pathTemp = "d:\\uploads\\";
    		if ((pathTemp.Length > 0) && (Directory.Exists(pathTemp))) {
    			foreach (string file in Directory.GetFiles(pathTemp)) {
    				try {
    					FileInfo fi = new FileInfo(file);
    					if (fi.CreationTime < DateTime.Now.AddHours(-8)) {
    						File.Delete(file);
    					}
    				} catch (Exception) { }
    			}
    		}
    	}
    
    	public void RemoveTemporaryFilesSchedule() {
    		HttpRuntime.Cache.Insert("RemoveTemporaryFiles", string.Empty, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, delegate(string id, object o, CacheItemRemovedReason cirr) {
    			if (id.Equals("RemoveTemporaryFiles", StringComparison.OrdinalIgnoreCase)) {
    				RemoveTemporaryFiles();
    				RemoveTemporaryFilesSchedule();
    			}
    		});
    	}
    }
