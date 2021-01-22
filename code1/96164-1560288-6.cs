    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.Net;
    using System.Xml;
    using System.IO;
    
    public partial class Weather : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    String reqUrl = "http://xoap.weather.com/weather/local/29206?cc=*&dayf=" +
    ConfigurationSettings.AppSettings.Get("ExtForecastLength") +
    "&prod=xoap&par=" + ConfigurationSettings.AppSettings.Get("PartnerID") +
    "&key=" + ConfigurationSettings.AppSettings.Get("LicenseKey");
    // First we request our content from our provider source .. in this case .. The Weather Channel
    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(reqUrl);
    //load the response into a response object
    WebResponse resp = wr.GetResponse();
    // create a new stream that can be placed into an XmlTextReader
    Stream str = resp.GetResponseStream();
    XmlTextReader reader = new XmlTextReader(str);
    reader.XmlResolver = null;
    // create a new Xml document
    XmlDocument doc = new XmlDocument();
    doc.Load(reader);
    // set out object properties
    Xml1.Document = doc;
    Xml1.TransformSource = "XSLTFile.xslt";
    
    
    }
    }
