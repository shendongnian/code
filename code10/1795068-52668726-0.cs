    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.Tag=="Player") {
    
                other.GetComponent<Guy>().health -= damage;
                Debug.Log(other.GetComponent<Guy>().health);
                Destroy(gameObject);
            }
        }
