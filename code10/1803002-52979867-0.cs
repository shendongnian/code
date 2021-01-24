    private void OnCollisionEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            //other.transform.Translate((Vector3.up * Time.deltaTime), Space.World);
            Player.GetComponent<Rigidbody>().AddForce(particleDirection * Speed);
            print("Pushing");
        }
    }
