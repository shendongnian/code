    GameObject[] spaceinvader;
    int length;
    // Start is called before the first frame update
    void Start()
    {
        spaceinvader = GameObject.FindGameObjectsWithTag("your tag");
        length = spaceinvader.Length;
    }
    // Update is called once per frame
    void increasespeed()
    {
        for (int i = 0; i < length; i++)
        {
            spaceinvader[i].GetComponent<yourspeedscript>().speed += 1;
        }
    }
