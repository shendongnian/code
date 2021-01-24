    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Despawner")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Char")
        {
            Destroy(this.gameObject);
            ScoreHandler.coinsCollected++;
        }
    }
