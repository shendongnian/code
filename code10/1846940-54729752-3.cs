    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Enemy"))
        {
            other.GetComponent<DamageBehavior>().TakeDamage();
        }
    }
