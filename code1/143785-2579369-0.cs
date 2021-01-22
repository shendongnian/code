    // the actual assignment will go in the constructor.
    private readonly Lazy<List<Note>> _notes = new Lazy<List<Note>>(CalcNotes);
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public List<Note> Notes
    {
        get { return _notes.Value; }
    }
