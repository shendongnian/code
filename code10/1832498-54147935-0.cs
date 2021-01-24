    IEnumerator ContinuousShoot()
    {
        // Continuously spawn bullets until this coroutine is stopped
        // when the player exits the trigger.
        while (true)
        {
            yield return new WaitForSeconds(1f); // Pause for 1 second.
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Player enters trigger
        if (other.gameObject.CompareTag("player"))
        {
       		StartCoroutine(ContinuousShoot());
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        // Player exits trigger
        if (other.gameObject.CompareTag("player"))
        {
       		StopCoroutine(ContinuousShoot());
        }
    }
