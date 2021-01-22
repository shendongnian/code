    private List<VidMark> _VidMarks;
    private List<VidMark> _UndoVidMarks;
    
    //Other methods instantiate and fill the lists
    private void SetUndoVidMarks()
    {
        _UndoVidMarks = _VidMarks.Clone();
    }
