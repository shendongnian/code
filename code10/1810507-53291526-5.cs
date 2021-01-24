    private Text[] array;
    private void Awake()
    {
        Text[] array = GameObject.FindObjectsOfType<Text>();
    }
    private void Update()
    {
        foreach (var x in array)
        {
            if (string.Compare(x.text, "Hello") == 0)
            {
                // The stuff to do here
            }
        }
    }
