    void Start()
    {
        StartCoroutine(meh()); //OR: StartCoroutine("meh"); //Both will work just fine..
    }
    
    private IEnumerator meh()
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Bye");
    
    }
