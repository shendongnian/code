    public class HomeController : Controller
    {
    
    public string Index()
    {
    
        HttpCookie cookie = Request.Cookies["message"];
        Message message = null;
        string json = "";
    
        if (cookie == null)
        {
            message = new Message();
            json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(message);
            cookie = new HttpCookie("message", json);
        }
        Response.Cookies.Add(cookie);
        return json;
    }
    
    public string CustomerAdded(int id)
    {
        HttpCookie cookie = Request.Cookies["message"];
        Message message = null;
        string json = "";
    
        if (cookie == null || string.IsNullOrEmpty(cookie.Value))
        {
            message = new Message();
            json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(message);
            cookie = new HttpCookie("message", json);
        }
        else
        {
            json = cookie.Value;
            message = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Message>(json);
        }
    
        if (message.Customers == null) message.Customers = new List<int>();
        if (message.Items == null) message.Items = new List<int>();
    
        if (!message.Customers.Contains(id))
        {
            message.Customers.Add(id);
        }
    
    
        json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(message);
        cookie = new HttpCookie("message", json);
    
        Response.Cookies.Add(cookie);
    
        return json;
    }
    
    
    public string ItemAdded(int id)
    {
        HttpCookie cookie = Request.Cookies["message"];
        Message message = null;
        string json = "";
    
        if (cookie == null || string.IsNullOrEmpty(cookie.Value))
        {
            message = new Message();
            json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(message);
            cookie = new HttpCookie("message", json);
        }
        else
        {
            json = cookie.Value;
            message = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Message>(json);
        }
        if (message.Customers == null) message.Customers = new List<int>();
        if (message.Items == null) message.Items = new List<int>();
    
        if (!message.Items.Contains(id))
        {
            message.Items.Add(id);
        }
    
        json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(message);
        cookie = new HttpCookie("message", json);
    
        Response.Cookies.Add(cookie);
    
        return json;
    }
    
    public string Submit()
    {
        HttpCookie cookie = Request.Cookies["message"];
        Message message = null;
        string json = "";
    
        if (cookie == null || string.IsNullOrEmpty(cookie.Value))
        {
            return "no data";
        }
        else
        {
            json = cookie.Value;
            message = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Message>(json);
        }
    
        Response.Cookies["message"].Value = "";
        Response.Cookies["message"].Expires = DateTime.Now.AddDays(-1);
    
        return "Submited";
    
    }
    }
