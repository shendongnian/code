    In controller:
    public ActionResult Delete(int? id)
                    {
                        if (id == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        Inventory inventory = _context.Inventory.Find(id);
                        if (inventory == null)
                        {
                            return HttpNotFound();
                        }
                        return View(inventory);
                    }
     
    in index add delete btn, this is an ajax call to the delete btn its used with dataTables to render data faster..
        {
    "render": function (data, type, row, meta) {
                   return '<a class="btn btn-danger" 
                    href ="@Url.Action("Delete", "Inventory")/' + row.Id + '">Delete</a>'; 
     }
