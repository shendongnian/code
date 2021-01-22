    public ActionResult TestRouting(string query)
    {
        if (query == "NewYork") 
        {
            var controller = new AvailabilityController();        
            return controller.Index();
        }
        else if (query == "name-of-business")
            return Redirect("nameofbusines.aspx?id=2731");       <--------- not sure
        else 
        {
            var controller = new TestController();        
            return controller.TestTabs();
        }
    }
