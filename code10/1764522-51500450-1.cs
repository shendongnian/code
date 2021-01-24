    IEnumerator StartMoveMent()
    {
        Rigidbody targetRb = GetComponent<Rigidbody>();
    
        while (true)
        {
            //Generate random position
            Vector3 destination = new Vector3();
            destination.y = 0;
            destination.x = UnityEngine.Random.Range(0, 50);
            destination.z = UnityEngine.Random.Range(0, 50);
    
            //Move and wait until the movement is done
            yield return StartCoroutine(MoveRigidbody(targetRb, destination, 30f));
        }
    }
