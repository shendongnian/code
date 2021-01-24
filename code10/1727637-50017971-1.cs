    public class ConfigFile
    {
        public DateTime Updated { get; set; }
        public int ID { get; set; }
        public List<int> Countries { get; set; }
    }
    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
         if (file.ContentLength > 0)
         {
             string inputString = (new StreamReader(file.InputStream)).ReadToEnd();
             JavaScriptSerializer jss = new JavaScriptSerializer();
             var configFile = jss.Deserialize<ConfigFile>(inputString);
         }
         return View();
    }
