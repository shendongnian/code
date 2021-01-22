    private string[] WordList()
    {
        using (DataContext db = new DataContext())
        {
           return db.Words.Select( x => x.Word ).OrderBy( x => x ).ToArray();
        }
    }
