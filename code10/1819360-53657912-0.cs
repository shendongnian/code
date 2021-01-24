    private void OnCollisionEnter2D(Collision2D collision) // or OnCollisionStay2D
    {
        Physics2D.IgnoreCollision (this.gameObject.GetComponent<Collider2D> (), collision.gameObject.GetComponent<Collider2D> ());
        Destroy(this.gameObject);
        ScoreHandler.coinsCollected++;
    }
