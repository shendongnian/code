    private void Update() 
    {
		void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Laser")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            if (transform.position.y < (-5.71f))
            {
                float Randomx = Random.Range(-5, 5);
                transform.position = new Vector3(Randomx, 5.71f, 0);
            }
        }
    }
