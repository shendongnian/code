    public JsonResult IsEmailExists([Bind(Prefix="Customer.CustomerEmail")] string CustomerEmail)
    {
        emedicineEntities _db = new emedicineEntities();
        return Json(!_db.Customers.Any(x => x.CustomerEmail == CustomerEmail), JsonRequestBehavior.AllowGet);
    }
