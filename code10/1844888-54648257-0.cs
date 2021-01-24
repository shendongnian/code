    public Button Button1;
    public Button Button2;
    
    void Start() {
        // We are adding a listener so our method will be called when button is clicked
        Button1.onClick.AddListener(Button1Clicked);
    }  
  
    void Button1Clicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        Button1.gameObject.SetActive(false);
        StartCoroutine(ButtonDelay());
    }
    IEnumerator ButtonDelay()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(10f);
        Debug.Log(Time.time);
        // This line will be executed after 10 seconds passed
        Button2.gameObject.SetActive(true);
    }
