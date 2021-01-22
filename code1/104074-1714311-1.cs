    public ActionResult Index(string submit)
            {
                switch (submit)
                {
                    case "Save":
                        // Do something
                        break;
                    case "Process":
                        // Do something
                        break;
                    default:
                        throw new Exception();
                        break;
                }
    
                return View();
            }
