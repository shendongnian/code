     public ActionResult Index()
     {
         AddService addService = new AddService();
         Dictionary<string,List<string>> SpecialityDoctorMap =
         addService.GetDoctorSpecialityList();
         return View(SpecialityDoctorMap); // passing model to view
     }
