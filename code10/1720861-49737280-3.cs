        [HttpPost("postself")]
        public IActionResult post([FromBody]JArray email)
        {
            try
            {
                var service = new EmailService();
                var emailHtml = service.GenerateEmail(email.ToString(), false);
                return Json(new { Email = emailHtml });
            }
            catch
            {
                return Json(new { Email = "error" });
            }
        }
