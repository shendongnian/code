    public Scrollbar scrollBar;
    private float oldValue;
    
    public delegate void SizeChanged(float oldValue, float newValue);
    public event SizeChanged OnSizeChanged;
    
    void Start()
    {
        oldValue = scrollBar.size;
    }
    
    void Update()
    {
        //Check if size changed
        if (!Mathf.Approximately(oldValue, scrollBar.size))
        {
            //Invoke the event
            if (OnSizeChanged != null)
                OnSizeChanged(oldValue, scrollBar.size);
    
            //It changed. Update old value with the new value
            oldValue = scrollBar.size;
        }
    }
