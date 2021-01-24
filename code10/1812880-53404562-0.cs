    [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Submit(ViewModel model)
        {
            var isValid = true;
            if (isValid)
            {
                return Json(new
                {
                    success = true
                });
            }
            return Json(new
            {
                success = false
            });
        }
