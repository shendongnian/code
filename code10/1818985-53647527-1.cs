    private int a;
    private int b;
    public bool Status => a == b;
    private void DoSomething()
    {
        a = ...;
        b = ...;
        // ...
        OnPropertyChanged(nameof(Status));
    }
