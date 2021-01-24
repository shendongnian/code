    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");
    
        if (collision.relativeVelocity.y <= 0)
        {
            Debug.Log("RelativeVelocity <=0");
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
            Destroy(collision.gameObject);
    
            currentScore += 10;
            displayScore.text = "Score: " + currentScore;
        }
    }
