    [HttpPost]
    public IActionResult Contacts(EmailModel model)
    {
        if(!ModelState.IsValid)
        {
            return View("Contacts", model);
        }
       ///some code
       ModelState.Clear();
        return View("Contacts", new EmailModel() );
    }
