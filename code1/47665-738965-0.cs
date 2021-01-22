    private void ProgressPropertyChangedHandler(object sender,
                                                PropertyChangedEventArgs args)
    {
        // fetch property on event handler thread, stash copy in lambda closure
        var progress = LongOp.Progress;
        // now update the UI
        pbProgress.Invoke(new Action(() => pbProgress.Value = progress));
    }
