    public GameObject Coin; // Gameobject with coin
    public Text CoinCounter; // Text with counter that shows in game
    private int _totalCounter = 0; // Int for counting total amount of picked up coins
    // I guess it's supposed to be Start here
    void Start()
    {
       // Converting text counter to Numbers
       int.TryParse(CoinCounter.text, out _totalCounter); 
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != Coin) return;
        // later this should probably rather be
        //if(collision.gameObject.tag != "Coin") return
        _totalCounter += 1; // adding 1 to total amount when player touching coin 
        CoinCounter.text = _totalCounter.ToString(); // Converting to Text, and showing up in UI
    
        Coin.SetActive(false); // Hiding coin
        // later this should probably rather be
        //collision.gameObject.SetActive(false);
    }
