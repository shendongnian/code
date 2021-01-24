    [HttpGet]
    [Authorize(Roles = "Parish Admin, Priest, Administrator")]
    public ActionResult Create() {
        var model = new CreateInvoiceViewModel {
            //set default property values as needed
        };
        
        //...
        
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Parish Admin, Priest, Administrator")]
    public ActionResult Create(CreateInvoiceViewModel model) {
        if (ModelState.IsValid) {
            var file = model.File;
            //copy properties over to entity
            var invoice = new Invoice {
                Company = model.Company,
                Description = model.Description,
                Amount = model.Amount,
                DateReceived = model.DateReceived,
                ChurchId = model.ChurchId,
                //create array for file contents
                PictureOfInvoice = new byte[file.ContentLength]
            };
            //populate byte array
            file.InputStream.Read(invoice.PictureOfInvoice, 0, file.ContentLength);
            
            db.Invoices.Add(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //if we get this far model state is invalid.
        //return view with validation errors.
        ViewBag.ChurchId = new SelectList(db.Churches, "ChurchId", "Name", model.ChurchId);
        return View(model);
    }
    
