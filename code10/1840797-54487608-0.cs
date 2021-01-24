      public IActionResult Sec()
        {
            var viewModel = new LoginVm();
            viewModel.ReturnUrl = "http://stackoverflow.com";
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Sec(LoginVm viewModel)
        {
           return Redirect(viewModel.ReturnUrl);
        }
