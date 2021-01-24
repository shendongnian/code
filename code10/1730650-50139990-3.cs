    [HttpPost]
    public ActionResult AddToCartWithQuantity(int id, int chosenQuantity)
    {
        // Your existing code to save. Use id to get the product
        // to do  :replace the hard coded 1 with actual value from db
        return Json(new { status = "success", cartItemCount = 1 });
    }
