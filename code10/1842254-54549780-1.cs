    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //do stuff
        }
        if(other.CompareTag("NPC"))
        {
            //do other stuff
        }
    }
