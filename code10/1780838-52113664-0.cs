    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ground" && rb.velocity.y < 0)
        {
            canJump = true;
        }
    }
