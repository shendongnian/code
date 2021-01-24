     public GameObject[] buttons;
     float[] buttonPos;
    private void Start()
    {
        buttonPos = new float[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonPos[i] =  buttons[i].transform.position.y;
            print(buttonPos[i]);
        }
       
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DestroyButton(1);
        }
    }
    void DestroyButton(int i)
    {
        Destroy(buttons[i]);
        Stack(i);
    }
    void Stack(int i)
    {
        for ( int j= i; j < buttons.Length; j++)
        {
            if(j != buttons.Length-1)
            buttons[j + 1].transform.position = new Vector3(buttons[j + 1].transform.position.x, buttonPos[j], buttons[j + 1].transform.position.z);
        }
         
    }
