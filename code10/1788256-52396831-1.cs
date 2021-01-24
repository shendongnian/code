    public ActionResult GetAprovedForPay(DateTime? fi = null, DateTime? ff = null)
    {
        var result = _repo.GetAprovedForPay(fi, ff);
        return RedirectToAction("SetDataExcel", new { obj = result });   
    }
