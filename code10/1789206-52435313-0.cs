    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemCard.SetActive(true);
        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {       
      
            ItemCard.SetActive(false);
        }
        
    }
