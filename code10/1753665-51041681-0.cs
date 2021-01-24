    public ActionResult Person()
        {
            Person hooman = new Person()
            {
                FirstName = "Parker",
                LastName = "Smith",
                Age = 30,
                DateOfBirth = new DateTime(1988, 01, 01),
                Email = "psmith@gmail.com",
                Telephone = "0851943376",
                Smoker = "No",
                SeriousIllness = "No",
            };
    
            return View(hooman);
        }
