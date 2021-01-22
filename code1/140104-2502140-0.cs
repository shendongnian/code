You can abstract away the struct as well:
    private Vector2 position;
    public float X
    {
        get
        {
            return position.X;
        }
        set
        {
            position.X = value;
        }
    }
