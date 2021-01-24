    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Tag of object that is expected to collide") {
            _pitcha.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 5000));
        }
    }
