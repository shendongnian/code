    [HttpPost]
    public ActionResult AddToCartWithQuantity(NewProjectModel product, int chosenQuantity)
    {
        // Your existing code to save
        // to do  :replace the hard coded 1 with actual value from db
        return Json(new { status = "success", cartItemCount = 1 });
    }
