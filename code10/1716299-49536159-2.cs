    public class HomeController : Controller
    {
    // GET: Home
    public ActionResult Index()
    {
        List<CustomerModel> customers = new List<CustomerModel>();
 
        //Load the XML file in XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("~/XML/Customers.xml"));
 
        //Loop through the selected Nodes.
        foreach (XmlNode node in doc.SelectNodes("/Customers/Customer"))
        {
            //Fetch the Node values and assign it to Model.
            customers.Add(new CustomerModel
            {
                CustomerId = int.Parse(node["Id"].InnerText),
                Name = node["Name"].InnerText,
                Country = node["Country"].InnerText
            });
        }
 
        return View(customers);
    }
    }
