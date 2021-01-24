    bool keepChecking = true;
    void OnCollisionStay(Collision collision)
    {
        if(keepChecking)
        {
            if(collision.gameobject.tag == "Wall")
            {
                collision.gameobject.transform.position = new Vector3(Random.Range(-33.0f, 30.0f), 2.35f, Random.Range(30.0f, -35.0f));
            }
            else
            {
                 keepChecking = false;
            }
         }
    }
