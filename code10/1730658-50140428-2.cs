    void OnCollisionEnter (Collision other)
    {
        if(other.gameobject.tag == "Enemy")
       {
            health = health - 20f;
            Debug.Log("hit");
        }
    }
