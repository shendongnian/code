    public SelectList GetStaff()
    {
         var staffList = _db.Staff.Select(s => new
         {
               Value = s.StaffID,
               Text = s.FirstName + " " + s.LastName
         }).ToList();
    
        return new SelectList(staffList, "Value", "Text");
    }
