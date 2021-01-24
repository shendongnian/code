    void Update() {
    	if (someReason) {
    		HandleCollision(someGameObject)
    	}
    }
    
    void HandleCollision(GameObject gameObject) {
    	if (gameObject.name == "Front_Buildings")
        {
            GetComponent<Animator>().SetBool("isGrounded", true);
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
    	HandleCollision(col.gameObject);    
    }
