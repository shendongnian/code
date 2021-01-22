    using System;
    using System.Data.ProviderBase;
    using System.Text;
    using System.Xml.Schema;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    using System.Globalization;
    using System.Diagnostics;
    using System.ComponentModel.Design;
    using System.Data.Common;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Collections;
    using System.Data;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Configuration;
    using System.Web.Security;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    
        protected void upload_Click(object sender, EventArgs e)
        {
    if (fileupload.HasFile)
    try {
    
        fileupload.SaveAs("C:\\Uploads\\" + fileupload.FileName);
    lbl.Text = "File name: " +
    fileupload.PostedFile.FileName + "<br>" +
    fileupload.PostedFile.ContentLength + " kb<br>" +
    "Content type: " +
    fileupload.PostedFile.ContentType;  
    }
    catch (Exception ex) {
    lbl.Text = "ERROR: " + ex.Message.ToString(); 
    }
    else
    {
    lbl.Text = "You have not specified a file.";
    } 
        }
    }
    
