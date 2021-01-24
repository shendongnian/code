     public ActionResult Registration()
            {
                var regViewModel = new UserRegistrationViewModel { Email = Request.QueryString["Email"] };
                return View(regViewModel);
            }
