    [HttpPost]
    public ActionResult Email(ServiceRequest myData)
    {
        try
        {
            var myConcatenatedSrr = 
            string.Join(",",myData.prop1,myData.prop2,myData.prop3, ....)
            //Your e-mail logic here... 
        }
        catch (System.Exception)
        {
            throw;
        }
    }
