            [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {
                    Page page = new Page();
                    page.Name = collection["Page.Name"];
                    page.TemplateID = int.Parse(collection["Page.Template"]);
                    page.Created = DateTime.Now;
                    
                    repPage.Add(page);
                    repPage.Save();
    
                    return RedirectToAction("Edit");
                }
                catch
                {
                    return View(new PageViewModel());
                }
            }
