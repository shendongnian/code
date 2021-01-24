    void Update()
	{
        if (timeToShoot >= 0f)
		{
            timeBetweenShotCounter -= Time.deltaTime;
			timeToShootCounter -= Time.deltaTime;
			if (timeBetweenShotCounter >= 0f)
            {
				Instantiate(Bullet, firePoint.position, firePoint.rotation);
				timeBetweenShotCounter = timeBetweenShot;
			}
		}
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
		    timeToShootCounter = timeToShoot;
			timeBetweenShotCounter = timeBetweenShot;
        }
    }
