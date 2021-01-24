     public Text textfield;
    // Start is called before the first frame update
    void Start()
    {
        textfield.text = "This is a Toast Message";
        textfield.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void TextShow()
    {
        textfield.enabled = true;
        Invoke("HideText", 2f);
    }
    public void HideText()
    {
        textfield.enabled = false;
        
    }
