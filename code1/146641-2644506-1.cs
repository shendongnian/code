    public class AdminController : Controller
    {
        public ActionResult LoadFoos()
        {
            if (Request.Files.Count > 0)
            {
                List<string> foos = new List<string>();
                using (StreamReader reader = new StreamReader(Request.Files[0].InputStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        foos.Add(line);
                    }
                }
                // TODO: use LINQ 2 SQL, NHibernate or ADO.NET to load the foos directly,
                // or call a web/WCF service behind your firewall that does this
            }
            return View();
        }
    }
