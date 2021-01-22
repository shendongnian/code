    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        // this will only be executed if postback
        // recreate controls from former postback
    }
    protected override object SaveViewState()
    {
        // TODO persist control hirarchie in here!! to allow restoring on next LoadViewState()
        return base.SaveViewState();
    }
