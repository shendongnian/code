    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
            JavaScriptSerializer jsonSer = new JavaScriptSerializer();
            jsonSer.RegisterConverters( new JavaScriptConverter[] { new SillyConverter() } );
            string json = jsonSer.Serialize(new SillyObject());
            Response.Write(json);
    
            SillyObject obj = jsonSer.Deserialize<SillyObject>(json);
            Response.Write(obj.SomeOtherProperty);
        }
    }
