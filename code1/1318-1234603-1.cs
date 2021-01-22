    public event EventHandler<ProgressEventArgs> ProgressChanged;
    private void OnProgressChanged(int processed, int total)
    {
        OnEvent(ProgressChanged, new ProgressEventArgs(processed, total));
    }
