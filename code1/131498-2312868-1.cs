    [AcceptVerbs("GET")]
    public ActionResult ViewAuditTrail()
    {
      var Audit = (from a in db.Audits orderby a.Timestamp descending select a).ToList();
      
      var AuditEntry = new List<AuditEntries>();
    
      foreach (var e in Audit)
      {
        var Staff = (from s in db.Staffs where s.ID == e.StaffID select s).SingleOrDefault();
    
        AuditEntries Entry = new AuditEntries();
        Entry.ID = e.ID;
        Entry.StaffName = Staff.Forename + " " + Staff.Surname + " (" + Staff.ID.ToString() + ")";
        Entry.Action = e.Action;
        Entry.Timestamp = e.Timestamp;
    
        AuditEntry.Add(Entry);
      }
    
      return View(AuditEntry.ToList());
    }
