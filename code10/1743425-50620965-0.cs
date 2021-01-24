    Rigidbody rb;
    public float force = 50;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Boundary"))
            rb.AddForce(col.contacts[0].normal * force, ForceMode.Impulse);
    }
