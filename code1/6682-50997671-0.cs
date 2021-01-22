    using System.Web.Script.Serialization;
    public ActionResult MyAction(string myParam)
    {
        
        return  new JavaScriptSerializer().Serialize(myObject);
    }
