    <!-- app/web.config --->
    <appSettings>
            <add key="filelocation" value="c:\xmlfiles"/>
    </appSettings>
    //c# code (in ASP.NET app, for example)
    using System.IO;
    using System.Xml.Linq;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["filelocation"];
            DirectoryInfo di = new DirectoryInfo(path);
            List<XDocument> xmlDocs = new List<XDocument>();
            foreach (FileInfo fi in di.GetFiles())
            {
                xmlDocs.Add(XDocument.Load(fi.FullName));
            }
        }
    }
