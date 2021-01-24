    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            // return view
        }
    
        ComplainTable et = oe.ComplainTables.Find(id);
        oe.ComplainTables.Remove(et);
        oe.SaveChanges();
        return RedirectToAction("Index");
    }
