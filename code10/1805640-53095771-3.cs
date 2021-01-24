    public ActionResult Approve(Events e)               <= Now "e" contains id=10, title="Abc", amount="123" and Finance_Approval="Approved"
    {
        if(e == null)
        {
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Events events = _context.evt.Find(e.id);        <= Fetch record of id=10 from database.
        events.Finance_Approval = e.Finance_Approval;   <= Assign changes to found record with posted data from view.
        _context.SaveChanges();
        return Content("Approved!");
    }
