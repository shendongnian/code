    [HttpPost]
    public IActionResult Contacts(EmailModel model)
    {
        if(!ModelState.IsValid)
        {
            return PartialView("Contacts", model);
        }
       ///some code
       ModelState.Clear();
        return PartialView("Contacts", new EmailModel() );
    }
