    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //destroy 'obsticle'
                Destroy(this.gameObject);
            }
        }
