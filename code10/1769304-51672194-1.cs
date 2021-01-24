    public JsonResult Autocomplete(string term){
    var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };
    var filteredItems = items.Where(item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
    return Json(filteredItems.Select(x => new
                {
                    fullName = x.FullName, 
                })); //, JsonRequestBehavior.AllowGet); }
