    private void OnTriggerEnter2D(Collider2D col)
    {
        // gets PlayerHealth component on this or any parent object
        var health = col.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            Attack(health);
        }
    }
    
    void Attack(PlayerHealth health)
    {
        timer = 0f;
        if(health.currentHealth > 0)
        {
            health.TakeDamage(attackDamage);
        }
    }
