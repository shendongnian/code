    public GameObject coin; // Gameobject with coin
    public Text CoinCounter; // Text with counter that shows in game
    private int TotalCounter = 0; // Int for counting total amount of picked up coins
    // I guess it's supposed to be Start here
    void Start()
    {
       int.TryParse(CoinCounter.text, out TotalCounter); // Converting text counter to Numbers
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TotalCounter += 1; // adding 1 to total amount when player touching coin 
        CoinCounter.text = TotalCounter.ToString(); // Converting to Text, and showing up in UI
    
        coin.SetActive(false); // Hiding coin
    }
