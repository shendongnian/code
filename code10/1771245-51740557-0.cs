    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(delegate{  
               Execute_IfPuzzleCompleted(YourObjectHere);})
    }
