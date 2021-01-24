    [Function(Name = "[dbname].[FoodCountCompare]")]
    public List<FoodCountCompare> GetFoodCountCompare(){
    	string UserId = User.Identity.GetUserId();
    	var dc = new DataClasses1DataContext();
    	var x = dc.FoodCountCompare(UserId).ToList();
    	var items = x.Select(d => new FoodCountCompare { Type = d.Type, Day = d.Day, Count = d.Count }) 
    	return items;
    }
    
    public JsonResult FoodCountCompare(){       
    	var items = new List<FoodCountCompare>(GetFoodCountCompare());
    	return Json(new {
    		Protein = items.Where(d => d.Type == "P"),
    		Hec = items.Where(d => d.Type == "H"),
    		Lec = items.Where(d => d.Type == "L"),
    		F = items.Where(d => d.Type == "O"),
    	}, JsonRequestBehavior.AllowGet);
    }
