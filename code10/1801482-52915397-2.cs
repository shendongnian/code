		[HttpPost]
		public ActionResult AddAsync(SampleViewModel deviceRegistration)
		{   
			Task.Run(()=>
			{
				//Saving to DB
			});
			return RedirectToAction("Details", id = deviceRegistration.id);
		}
		public ActionResult Details(int id)
		{
			var isObjectExistInDb = checkIfExistInDb(id);
			if (!isObjectExistInDb){
				return View("ShowLoader", id);
			}
			
			return View(object);
		}
