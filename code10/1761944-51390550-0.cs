    private int _age = 0;
    public int Age
    {
        get => _age;
        set
        {
            if (value > 0)
                _age = value;
        }
    }
