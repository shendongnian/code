    public ActionResult VEmployees() 
    {
            InfoDBContext infoContext = new InfoDBContext();
     
            List<Visa> vEmployees = infoContext.Visas.Include(e => e.EmployeeInfo).Where(v => v.VisaName == "Hunain").ToList();
            return View(vEmployees);
     }
