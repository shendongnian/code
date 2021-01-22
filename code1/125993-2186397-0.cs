    public ActionResult AddToFavorites(int documentID, int page, string query)
    {
         // Do the work to add the document to favorites
         return RedirectToAction("ActionName", new { Page = page, Query = query}); // where "ActionName" is the name of the action that the user was on before they got here
    }
