    DateTime startTime;
    public TimeSpan timeElapsed { get; private set; }
    private void Start()
    {
        startTime = DateTime.Now;
    }
    
    private void Update()
    {
        this.timeElapsed= DateTime.Now - startTime;
    }
