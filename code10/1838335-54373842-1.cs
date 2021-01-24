       [HttpPost]
        // Add attribute to current provider model
        public IActionResult Index(Provider provider)
        {
            provider.Attributes.Add(new Models.Attribute());
            return View(provider);
        }
