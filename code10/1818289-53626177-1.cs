     public IActionResult PestsonDetails(int id)
     {
            //you can search database with person id 
            Person p = new Person();
            p.FirstName = "FirstName";
            p.LastName= "LastName";
            p.Age = 28;
            Dictionary<string, string> personDetails = new Dictionary<string, string>();
            foreach (PropertyInfo prop in p.GetType().GetProperties())
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(p, null);
                personDetails.Add(propName.ToString(),propValue.ToString());
            }
            ViewBag.personDetails = personDetails;
            return View();
      }
