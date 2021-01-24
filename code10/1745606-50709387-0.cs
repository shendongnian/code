    public ActionResult Create()
    {
         var clients = new List<Clients>
         {
               new Clients { ClientsId = 50, Name = "Timo" },
               new Clients { ClientsId = 51, Name = "Microsoft" }
         };
    
         var vm = new Animals
         {
             ClientsList = clients
         };
         return View(vm);
    }
