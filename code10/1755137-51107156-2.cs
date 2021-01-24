    [HttpPost]
    public ActonResult Add(DriverViewModel DVM)
    {
        var repo = new VehicleRepository();
        var driver = new Driver();
        
        //tools such as automapper or tinymapper are often used so that you dont
        //need to manually make these assignments
        driver.DriverLastName = DVM.DriverLastName;
        driver.DriverFirstName = DVM.DriverFirstName;
        driver.DriverLicense = DVM.DriverLicense;
        driver.LicenseExpiry = DVM.LicenseExpiry;
        driver.MobileNumber = DVM.MobileNumber;
        driver.BusinessUnit = DVM.BusinessUnit;
        driver.DateRegistered = DVM.DateRegistered;
    
        repo.AddDriver(driver);
        //return whatever view you want to go to after the save
        return View("Index");
    }
