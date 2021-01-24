        @*Add this at end of razor view*@
         @section Scripts {
           @Scripts.Render("~/bundles/jqueryval")
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Sign_Up(Sign_up sign_upmodel)
        {
            if (ModelState.IsValid)
            {
                // Your logic here. Save to DB etc..
                return RedirectToAction("Index"); // return to some page.
            }
            // Model Validation Failed so return the same Get View.
            return View(sign_upmodel);
        }
