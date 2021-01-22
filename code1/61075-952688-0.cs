    using System;
    using System.Web;
    using System.Xml;
    
    public class Handler : IHttpHandler
    {
    	public void ProcessRequest( HttpContext context)
    	{
    		context.Response.ContentType = "application/vnd.google-earth.kml+xml";
    		context.Response.AddHeader("Content-Disposition", "attachment; filename=MelroseVista.kml");
    				
    		XmlTextWriter kml = new XmlTextWriter(context.Response.OutputStream, System.Text.Encoding.UTF8);
    
    		kml.Formatting = Formatting.Indented;
    		kml.Indentation = 3;
    
    		kml.WriteStartDocument();
    
    		kml.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
    		kml.WriteStartElement("Placemark");
    		kml.WriteElementString("name", "Melrose Vista   FL");
    		kml.WriteElementString("description", "A nice little town");
    
    		kml.WriteStartElement("Point");
    
    		kml.WriteElementString("coordinates", "-80.18451400000000000000,26.08816400000000000000,0");
    
    		kml.WriteEndElement(); // <Point>
    		kml.WriteEndElement(); // <Placemark>
    		kml.WriteEndDocument(); // <kml>
    
    		kml.Close();
    		
    	}
    	public bool IsReusable
    	{
    		get
    		{
    			return false;
    		}
    	}
    }
