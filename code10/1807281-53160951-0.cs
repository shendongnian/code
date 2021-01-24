    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack1());
        button2.onClick.AddListener(() => buttonCallBack2());
        button3.onClick.AddListener(() => buttonCallBack3());
        button4.onClick.AddListener(() => buttonCallBack4());
    }
    private void buttonCallBack1() { }
    private void buttonCallBack2() { }
    private void buttonCallBack3() { }
    private void buttonCallBack4() { }
