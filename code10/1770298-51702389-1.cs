    public ActionResult Delete(int id)
    {
        if (id == 0)
        {
            // return view
        }
    
        ComplainTable et = oe.ComplainTables.Find(id);
        oe.ComplainTables.Remove(et);
        oe.SaveChanges();
        return RedirectToAction("Index");
    }
