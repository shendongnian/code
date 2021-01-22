    private Lazy<IList<Note>> notes;
    public IEnumerable<Note> Notes
    {
        get
        {
            return this.notes.Value;
        }
    }
    // In constructor:
    this.notes = new Lazy<IList<Note>>(this.CalcNotes);
