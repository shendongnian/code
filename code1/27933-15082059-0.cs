    //model
    	public class input_element
        	{
         	 public string Btn { get; set; }
        	}	
    
    //views--submit btn can be input type also...
    	@using (Html.BeginForm())
    	{
        		<button type="submit" name="btn" value="verify">
           		 Verify data</button>
        		<button type="submit" name="btn" value="save">
           		 Save data</button>    
        		<button type="submit" name="btn" value="redirect">
           	         Redirect</button>
    	}
    
    //controller
    
    	public ActionResult About()
            {
                ViewBag.Message = "Your app description page.";
                return View();
            }
         
            [HttpPost]
            public ActionResult About(input_element model)
            {
                    if (model.Btn == "verify")
                    {
                    // the Verify button was clicked
                    }
                    else if (model.Btn == "save")
                    {
                    // the Save button was clicked
                    } 
                    else if (model.Btn == "redirect")
                    {
                    // the Redirect button was clicked
                    } 
                    return View();
            }
