    private IEnumerator DecreaseSpeed ()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().forwardForce = 1f;
        Thread.Sleep(2000);
        GameObject.Find("Player").GetComponent<PlayerMovement>().forwardForce = 10f;
    }
