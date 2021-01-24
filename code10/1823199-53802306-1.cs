    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Product product, HttpPostedFileBase productImage)
    {
       if (ModelState.IsValid)
       {
          if (productImage != null && productImage.ContentLength > 0)
          {
              var fileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + Path.GetFileName(productImage.FileName);
              var path = Path.Combine(Server.MapPath("~/Content/Images/Product/"), fileName);
              productImage.SaveAs(path);
              product.ProductImage = fileName;
          }
          db.Products.Add(product);
          await db.SaveChangesAsync();
          return RedirectToAction("Index");
       }
    
       return View(product);
    } 
