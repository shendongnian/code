    public IActionResult UserInfo()
        {
            //The First method ,
            string s = (string)TempData.Peek("Model");
            //The Second method
            string s = (string)TempData["Model"]; 
            TempData.Keep("Model");
            if(s==null)
            {
                return View();
            }
            else
            {
                User model = JsonConvert.DeserializeObject<User>(s);
                return View(model);
            }
        }
