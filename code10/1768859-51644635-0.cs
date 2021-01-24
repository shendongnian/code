    void RollDice()
    {
        foreach (var die in _dice)
        {
            // Roll() adds force and torque from a given starting position
            die.GetComponent<Die>()
               .Roll(_rollStartPosition, Random.onUnitSphere * _rollForce, Random.onUnitSphere * _rollTorque);
        }
        StartCoroutine(CheckIfDiceAreMoving());
    }
    IEnumerator CheckIfDiceAreMoving()
    {
        while(anyDieIsMoving){
            anyDieIsMoving = false;
            foreach (var die in _dice)
            {
                var dieRigidbody = die.GetComponent<Rigidbody>();
                if (!dieRigidbody.IsSleeping())
                {
                    anyDieIsMoving = true;
                    yield return null;
                }
            }
        }
        // Calculate score and do something with it...
    }
