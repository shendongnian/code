    // POST: Fabric/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "FabricId,MainCategory,MainCategoryId, SubCategory1Id,SubCategory1,SubCategory2,Name,ImagePath,Location,Type,Weight,Content,Design,Brand,Quantity,Width,Source,Notes,ItemsSold")] Fabric fabric, HttpPostedFileBase file)
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(file.FileName);
                    string fabricId = fabric.FabricId.ToString();
                    string myfile = fabricId + "_" + filename;
                    var path = Path.Combine(Server.MapPath("~/images"), myfile);
                    fabric.ImagePath = myfile;
                    file.SaveAs(path);
                    db.Fabrics.Add(fabric);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(fabric);
            }
