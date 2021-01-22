    public IList<Note> GetMyNotes()
    {
    IList<Note> NoteList = (from x in db.HandheldNotes
                       join t in db.Employees on x.By equals t.EmployeeNo
                       orderby x.DateAdded
                       select new Note
                       {
                           DateRaised = x.DateAdded,
                           Note = x.Note,
                           TypeID = x.TypeID,
                           EmployeeID = t.Forenames + " " + t.Surname
                       }).ToList<Note>();
            return NoteList;
    }
