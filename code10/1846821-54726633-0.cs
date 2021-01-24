    void Start()
    {
        StartCoroutine(RevealNumber());
    }
    IEnumerator RevealNumber()
    {
        int c = 1;
        for (var a = 0; a < 9; a++)
        {
            for (var b = 0; b < 9; b++)
            {
                arr[a, b]  = c;
                c++;
                Upd();
                //waits for 1 second.
                yield return new WaitForSeconds(1);
            }
        }      
    }
