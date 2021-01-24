    IENumerator Fall(Rigidbody rigidbody)
    {
        //Make platforms fall
        yield return new WaitForSeconds(2f);
        rigidbody.useGravity = enabled;
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Platform(Clone)")
        {
            numberOfJumps = 2;
            Debug.Log("Platform hit");
        }
        StartCoroutine(Fall(collision.rigidbody));
    }
