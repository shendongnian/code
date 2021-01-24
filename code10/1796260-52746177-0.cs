    public PlaneFinderBehaviour plane;
        
    void Start()
    {
        ...
        buttonOnTheScene.onClick.AddListener(TaskOnClick);
        ...
    }
    void TaskOnClick()
    {
        Vector2 aPosition = new Vector2(0,0);
        ...
        plane.PerformHitTest(aPosition);
    }
