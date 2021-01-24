    // Flag for enabling and disabling damping
    private bool enableDamping;
    // speed with which the player passed the 3m mark
    private float initialSpeed;
    private void Update()
    {
        float distanceFromTarget = Vector3.Distance(character.transform.position, door.transform.position);
        if(distanceFromTarget > maxDistance)
        {
            // while far away only remember current speed and do nothing else
            initialSpeed = speed;
            enableDamping = true;
        }
        else if (distanceFromTarget <= maxDistance && distanceFromTarget > minDistance)
        {
            if(enableDamping)
            {
                DampSpeed(distanceFromTarget);
            }
        }
        else
        {
            if(enableDamping)
            {  
                // now speed should be zero but just to be sure
                speed = 0;
                character.SetFloat("Walking Speed", speed);
                // and the player minDistance from the door
                // you might want to disable the damping now so you can still move away again.
                enableDaming = false;
            }
        }
    }
