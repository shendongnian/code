        public async Task<IActionResult> Login(string redirectUrl)
        {
            HttpContext.Session.SetInt32("BranchId", 1);
            HttpContext.Session.SetString("Admin", "Admin");
            return Redirect(redirectUrl);
            //return Ok("Successfully Login");
        }
