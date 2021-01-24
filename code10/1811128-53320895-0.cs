    private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Player"))
                {
                    HealthBarScript.health -= 20f;
                }
    
            }
