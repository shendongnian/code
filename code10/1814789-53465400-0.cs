    void OnCollisionEnter(Collision other)
            {
    
                    if (other.collider.tag.Equals("Ground"))
                    {
                            Physics.IgnoreCollision(other.collider, boxCollider, true);
                    }
            }
