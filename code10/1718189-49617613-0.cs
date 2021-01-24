    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathCube") 
        {
            Destroy (gameObject);
        }
        if (other.gameObject.tag == "GoldCube") 
        {
            gold++;
        }
    }  
