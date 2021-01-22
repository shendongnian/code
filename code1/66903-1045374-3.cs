    // Method #1
    public ActionResult AssignRemovePretty(string parentName, string itemName) { 
        // Logic to retrieve item's ID here...
        string itemId = ...;
        return RedirectToAction("Assign", itemId);
    }
    // Method #2
    public ActionResult Assign(string itemId, string searchTerm, int? page) { ... }
