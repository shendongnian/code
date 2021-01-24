    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        // Here I'm using tag to detect if the hit object is a player or a box
        // but you can use name or other methods
        if (other.tag == 'Player' || other.tag == 'Box') {
            Destroy(other);
        }
    }
