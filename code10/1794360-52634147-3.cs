    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            rb.AddForce(-direction * moveSpeed, ForceMode.Impulse);
        }
    }
