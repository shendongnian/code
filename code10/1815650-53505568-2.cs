    public Transform  handleview;
    public Transform pressureview;
    public Transform wallview;
    public Transform sechandleview;
    public Transform pressuretwoview;
    public Transform switchview;
    // I made this serialized since actually you wouldn't need the 
    // single Transforms above anymore but directly reference them here instead
    [SerializeField] private List<Transform> _views;
    private int currentViewIndex;
    private void Awake()
    {
        _views = new List<Transform>()
        {
            handleview,
            pressureview,
            wallview,
            sechandleview,
            pressuretwoview,
            switchview
        }
        currentVIEW = handleView;
    }
