    Text[] array;
    void Awake()
    {
        Text[] array = GameObject.FindObjectsOfType<Text>();
    }
    void Update()
    {
        foreach (var x in array)
        {
            if(string.Compare(x.text,"hello") == 0)
            {
                // The stuff to do here
            }
        }
    }
