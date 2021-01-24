     public ActionResult Index()
            {
    
                Log.Models.LOGS.lstLogs = new List<Models.LOGS.ListOfLogs>();
                Models.LOGS.ListOfLogs inputlogs = new Models.LOGS.ListOfLogs();
                inputlogs.log = "This is your first log";
                
                Log.Models.LOGS.lstLogs.Add(inputlogs);
    
                inputlogs = new Models.LOGS.ListOfLogs();
                inputlogs.log = "This is your second log";
                
                Log.Models.LOGS.lstLogs.Add(inputlogs);
    
                return View();
            }
