    public ScrollRect scrollRect;
    
    void OnEnable()
    {
        scrollRect.onValueChanged.AddListener(ScrollChanged);
    }
    
    void OnDisable()
    {
        scrollRect.onValueChanged.RemoveAllListeners();
    }
    
    void ScrollChanged(Vector2 pos)
    {
        Debug.Log("Scroll changed pos to: " + pos);
    }
