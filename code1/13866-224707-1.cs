    SQLTransaction trans = null;
    using(trans = new SqlTransaction)
    {
        ...
        Do SQL stuff here passing my trans into my various SQL executers
        ...
        trans.Commit  // May not be quite right
    }
