    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
           enemy.DoDeathEffects(); //you will need to create this function.
           Destroy(gameObject);
        }
    }
