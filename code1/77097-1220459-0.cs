    using System.Web.Script.Serialization;
[...]
    if (Request.Form.HasKeys())
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        foreach (var key in Request.Form.AllKeys)
        {
            var value = Request.Form[key];
            var list = serializer.Deserialize<string[]>(value);
            
        }
    }
    
    
