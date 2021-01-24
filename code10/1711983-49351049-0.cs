    HttpPost] public ActionResult Question(FormCollection collection, Questions questions)
    {
        if (ModelState.IsValid)
        {
            var viewModel = new RegistrationViewModel { Questions = questions, Responses = response };
            return View("Question", viewModel);
        }
    }
    Response.next page 
