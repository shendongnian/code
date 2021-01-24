    public ActionResult Index()
            {
                var url = "https://api.github.com/users/{myuser}/repos";
    
                using (var webClient = new WebClient())
                {
                    var rawJSON = webClient.DownloadString(url);
                    RepCollections rep = JsonConvert.DeserializeObject<RepCollections>(rawJSON);
    
                    return View(rep);
                }
            }
