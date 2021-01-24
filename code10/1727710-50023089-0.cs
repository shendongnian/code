    public ActionResult MealPlannerAliments(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
		
		Aliment aliment = new Aliment();
		aliment = db.Aliment.Find(id);
		
		 if (aliment == null)
         {
            return HttpNotFound();
         }
		 else
		 {
			MealPlanner mealPlannerAliment = db.MealPlanners.Find(aliment.id);
        	if (mealPlannerAliment == null)
        	{
            	mealPlannerAliment = aliment;
				try{
					db.Add(mealPlannerAliment);
					db.saveChanges();
				}
				catch{
					ViewBag.Error('Error! Try Later!')
				}
        	}
			else{
				ViewBag.Error('this Aliment already exists in the Meal Planner')
			}
		 }
		
		
        return View();
    }
