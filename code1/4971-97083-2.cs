    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Management.Instrumentation;
    using System.Management;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManagementClass pWMIClass = null;
    
                pWMIClass = new ManagementClass(@"root\interiorhealth:MyWMIInterface");
    
                lblOutput.Text = "ClassName: " + pWMIClass.ClassPath.ClassName + "<BR/>" +
                     "IsClass: " + pWMIClass.ClassPath.IsClass + "<BR/>" +
                     "IsInstance: " + pWMIClass.ClassPath.IsInstance + "<BR/>" +
                     "IsSingleton: " + pWMIClass.ClassPath.IsSingleton + "<BR/>" +
                     "Namespace Path: " + pWMIClass.ClassPath.NamespacePath + "<BR/>" +
                     "Path: " + pWMIClass.ClassPath.Path + "<BR/>" +
                     "Relative Path: " + pWMIClass.ClassPath.RelativePath + "<BR/>" +
                     "Server: " + pWMIClass.ClassPath.Server + "<BR/>";
    
                //GridView control
                this.gvProperties.DataSource = pWMIClass.Properties;
                this.gvProperties.DataBind();
    
                //GridView control
                this.gvSystemProperties.DataSource = pWMIClass.SystemProperties;
                this.gvSystemProperties.DataBind();
    
                //GridView control
                this.gvDerivation.DataSource = pWMIClass.Derivation;
                this.gvDerivation.DataBind();
    
                //GridView control
                this.gvMethods.DataSource = pWMIClass.Methods;
                this.gvMethods.DataBind();
    
                //GridView control
                this.gvQualifiers.DataSource = pWMIClass.Qualifiers;
                this.gvQualifiers.DataBind();
            }
        }
    }
