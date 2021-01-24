    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "bullet") {
            healthCur -= collision.gameObject.GetComponent<Bullet>().Damage;
    
            if (healthCur <= 0) {
                Die();
            }
        }
    }
