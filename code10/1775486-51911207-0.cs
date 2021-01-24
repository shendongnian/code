    public int scores;
    public GameObject Rock1;
    
    IEnumerator Start()
    {
        //Wait until score is < 2000
        while (!(scores < 2000))
            yield return null;
    
        //Show Object
        Rock1.SetActive(true);
    
        //Wait again until score is > 2000
        while (!(scores > 2000))
            yield return null;
    
        //Hide Object
        Rock1.SetActive(false);
    
        //Done. Coroutine stops!
    }
