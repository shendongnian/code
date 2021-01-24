     public ActionResult AddToListSOH(string model)
        {
            if (Session["modelInputs"] == null)
            {
                List<string> temphandler1 = new List<string>();
                temphandler1.Add(model);
                Session["modelInputs"] = temphandler1;
            }
            else
            {
                List<string> temphandler2 = new List<string>();
                temphandler2 = (List<string>)Session["modelInputs"];
                temphandler2.Add(model);
                Session["modelInputs"] = temphandler2;
            }
            var result = new ModelDescription { modelsAdded = (List<string>)Session["modelInputs"] }; 
                
            return PartialView("AddToListSOH", result);
        }
