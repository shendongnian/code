    public GameObject coin;
    public Text CoinCounter;
    private float TotalCounter = 0; 
    private void Update()
    {}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TotalCounter = (TotalCounter + 1); 
        Debug.Log(TotalCounter); 
        CoinCounter.text = TotalCounter.ToString(); 
        Debug.Log(CoinCounter.text);
        coin.SetActive(false); 
    }
`
