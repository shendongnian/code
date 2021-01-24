    void OnCollisionEnter2D(Collision2D other) {
        var player = other.gameObject.GetComponent<Player>();
        if(player != null && player.isIndestructible){        
            SceneManager.LoadScene("Game");
        }
    }
