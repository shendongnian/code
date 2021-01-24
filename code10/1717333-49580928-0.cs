    public Transform player;
    public GUIText scoreText;
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString();
    }
