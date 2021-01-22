    private List<VidMark> _VidMarks;
    private List<VidMark> _UndoVidMarks;
    private void SetUndoVidMarks()
    {
        _UndoVidMarks = _VidMarks.Clone();
    }
