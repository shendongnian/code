    public GameOptions(GameObject canvas)
    {
        //here we instantiate the canvas item, assigning it to the field
        this.canvas = GameObject.Instantiate(canvas);  
    
        //then we reference the field item, instead of the parameter item
        Text[] textObjects = this.canvas.GetComponentsInChildren<Text>();
        Button[] buttonObjects = this.canvas.GetComponentsInChildren<Button>();
        for(int i = 0; i < buttonObjects.Length; i++)
        {
            Debug.Log(buttonObjects[i].name);
            buttonObjects[i].onClick.AddListener(() => clicked());
            buttonObjects[i].onClick.Invoke();
        }
    }
