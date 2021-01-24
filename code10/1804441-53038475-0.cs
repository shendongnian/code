       public Button b1;
    public TextMeshProUGUI b1text;
    void Start()
    {
        b1text = b1object.GetComponentInChildren<TextMeshProUGUI>();
        btnValue();
    }
    public void btnValue()
    {
        b1text.text = "sdfa";
    }
