    [HttpPut]
    public HttpResponseMessage Addfood(int id,[FromBody] Model model)
    {
        Food food = new Food();
        var userid = db.Users.FirstOrDefault(e => e.ID == id);
        if (userid == null)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Record Found");
        }
    
        food.UID = id;
        food.Name = model.Foodname;
        food.Price = model.Foodprice;
        food.Image = model.Foodimage;
        food.Date_Time = DateTime.Today;
        Category category = new Category();
        category.Name = model.Categoryname;
        food.Category = category;
        db.Foods.Add(food);
        db.SaveChanges();
        return Request.CreateResponse(HttpStatusCode.OK, food);
    }
