    public JsonResult OnPostAddEntitlement([FromBody] VacationEntitlement vacationEntitlement)
    {
       if(TempData.ContainsKey("Person")) {
         var person = TempData["Person"] as Person; /* (as Person} I just assume the class name is Person */
         // place your logic here
       }
    }
