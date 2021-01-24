    public static event EventHandler SubmittedQuantityChanged;
    public static string SubmittedQuantity
    {
        get => _SubmittedQuantity;
        set
        {
            if (value != _SubmittedQuantity)
            {
                _SubmittedQuantity = value;
                SubmittedQuantityChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
