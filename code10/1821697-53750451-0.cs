    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!boosting)
            {
                // stuff
                TankMovement collidedMovement = other.gameObject.GetComponent<TankMovement>();
                collidedMovement.m_Speed = 20f;
                // more stuff
            }    
        }
    }
