    // using Newtonsoft.Json;
    public IActionResult Contacts()
    {
        var model = new EmailModel { Name = "Test" };
        if (TempData[nameof(EmailModel)] is string json)
        {
            model = JsonConvert.DeserializeObject<EmailModel>(json);
        }
        return View(model);
    }
    [HttpPost]
    public IActionResult Contacts(EmailModel model)
    {
        model.Name = "After submit name";
        TempData[nameof(EmailModel)] = JsonConvert.SerializeObject(model);
        return RedirectToAction("Contacts");
    }
