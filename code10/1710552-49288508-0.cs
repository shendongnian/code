    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "InvoiceId,Company,Description,Amount,ChurchId")] Invoice invoice)
    {
        if (ModelState.IsValid)
        {
            Invoice oldInvoice = db.Invoices.Find(id);
            oldInvoice.Amount = invoice.Amount;
            // repeated for all of the properties (but not the image)
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ChurchId = new SelectList(db.Churches, "ChurchId", "Name", invoice.ChurchId);
        return View(invoice);
    }
