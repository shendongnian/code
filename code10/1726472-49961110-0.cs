    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    public float ResourceStone;
    // Use this for initialization
    void Start()
    {
        ResourceStone = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
