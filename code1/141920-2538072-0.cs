    public ActionResult Create()
            {
                ViewData["categories"] = new SelectList
                (
                    articleCategoryRepository.FindAllCategories().ToList(), "CategoryID", "Title"
                );
    
                Article article = new Article()
                {
                    Date = DateTime.Now,
                    CategoryID = 1
                };
    
                return View(article);
            }
