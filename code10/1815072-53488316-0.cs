    private MainScript whateverYouWannaCallIt;
    private Vector2[] geneCopies; 
    public void Awake()
    {
        whateverYouWannaCallIt = gameObject.GetComponent<MainScript>();
        for (int i = 0; i < whateverYouWannaCallIt.rockets.Length; i++)
        {
            geneCopies[i] = whateverYouWannaCallIt.rockets.gene[i];
        }
    }
