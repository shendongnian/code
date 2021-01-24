    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductAddModel model)
    {
        if (ModelState.IsValid)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Products", model.File.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
               await model.File.CopyToAsync(stream);
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ProductDataModel dataModel = new ProductDataModel()
            {
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Category = model.Category,
                Game = model.Game,
                Price = model.Price,
                ImagePath = model.File.FileName,
                DeveloperUserId = user.Id
            };
            context.Products.Add(dataModel);
            context.SaveChanges();
            return RedirectToAction("Products", "Admin");
        }
        return View(model);
    }
