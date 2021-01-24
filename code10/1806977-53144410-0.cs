    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public BoxCollider2D col3;
    public BoxCollider2D col4;
    
    void Awake()
    {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        col1 = colliders[0];
        col2 = colliders[1];
        col3 = colliders[2];
        col4 = colliders[3];
    }
