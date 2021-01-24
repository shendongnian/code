    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Platform(Clone)")
        {
            numberOfJumps = 2;
            Debug.Log("Platform hit");
        }
    
        //Maake platforms fall
        yield return new WaitForSeconds(2f);
        collision.rigidbody.useGravity = enabled;
        yield return null;
    }
