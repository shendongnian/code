    public void Enable()
    {
        OnEnable(); // Exceptions raised from here prevent the flag being set.
        IsEnable = true;
    }
