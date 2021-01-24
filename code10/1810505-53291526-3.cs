    Text[] array;
    void Awake()
    {
        Text[] array = GameObject.FindObjectsOfType<Text>();
    }
    void Update()
    {
        foreach (var x in array)
        {
            if(string.Compare(x.text,"Hello") == 0)
            {
                // The stuff to do here
            }
        }
    }
