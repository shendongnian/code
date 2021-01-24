    while(anyDieIsMoving){
        anyDieIsMoving = false;
        foreach (var die in _dice)
        {
            var dieRigidbody = die.GetComponent<Rigidbody>();
            if (!dieRigidbody.IsSleeping())
            {
                anyDieIsMoving = true;
                break;
            }
        }
        yield return null;
    }
