    public Rigidbody prefabInfection;
    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            Destroy(gameObject);
            Instantiate(prefabInfection, transform.position, transform.rotation);
        }
    }
