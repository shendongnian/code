    [HttpGet]
    [Route("{code}/CertificateValidation")]
    public ActionResult CertificateValidation()
    {
        var model = new IndexViewModel();
        return View(model);
    }
