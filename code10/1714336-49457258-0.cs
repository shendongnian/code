     [HttpPost]
     public ActionResult Phase1(int ecoleChoi1 , int programmeChoi1, string submiter)
     { 
          //... 
          //You can then reconstruct the model if necessary and send back
          ChoixModel model = new ChoixModel();
          //...
          return View(model);
     }
