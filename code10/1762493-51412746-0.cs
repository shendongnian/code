    public ActionResult Create()
    {
        var vm = new CreateVm();
        vm.CountriesList = new List<SelectListItem>
        {
         new SelectListItem { Value = "1", Text = "India" },
         new SelectListItem { Value = "2", Text = "Pakistan" },
         new SelectListItem { Value = "3", Text = "Nepal" },
         new SelectListItem {Value = "4", Text = "Sri Lanka" },
         new SelectListItem { Value = "5", Text = "Bangladesh" },
         new SelectListItem {Value = "6", Text = "Bhutan" }    
        };
  
        // user object is intstantiated somehave
        var country = db.Country.SingleOrDefault(u => u.CountryId == user.CountryID);
      
        if (country != null && vm.CountriesList
                               .Any(a => a.Value == country.CountryId.ToString()))
        {
             vm.Country = country.CountryId;
        }
        else
        {
             vm.Country = 1;  // Value of "India" option (select list)item
        }
        return View(vm);
    }
