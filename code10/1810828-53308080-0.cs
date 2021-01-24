    public float speedIncrement;
    
    // ...
    
    void OnTriggerEnter(Collider other)
    {
        // This will reduce unnecessary nesting in your code to make it easier to read
        if (!other.gameObject.CompareTag("Sphere"))
            return;
    
        // Same thing as GameManager.PrefabCount = GameManager.PrefabCount + 1
        GameManager.PrefabCount++; 
        
        if (GameManager.PrefabCount >= highScore)
        {
            highScore = GameManager.PrefabCount;
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save();
        }
        
        // Use the Modulus operator to determine if the PrefabCount is evenly divisible by 2
        if (GameManager.PrefabCount % 2 == 0)
            Speed += speedIncrement; // Increase speed by whatever value set in the inspector
    }
