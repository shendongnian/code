    using System.Web.Script.Serialization;
    public string ToJson(object o)
    {
      JavaScriptSerializer serializer = new JavaScriptSerializer();
      return serializer.Serialize(o);
    }
