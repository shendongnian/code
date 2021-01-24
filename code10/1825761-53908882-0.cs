    //different button objects
    [SerializeField] private GameObject smithbutton;
    [SerializeField] private GameObject innbutton;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
    //debugs which collider player is in
        if (col.gameObject.tag == "Blacksmith")
        {
            ButtonActivationToggle(smithbutton, col);
        }
        if (col.gameObject.tag == "Inn")
        {
            ButtonActivationToggle(innbutton, col);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
    //once playerobject exits, button will toggle and disappear
        if (col.gameObject.tag == "Blacksmith")
        {
            ButtonActivationToggle(smithbutton, col);
        }
        if (col.gameObject.tag == "Inn")
        {
            ButtonActivationToggle(innbutton, col);
        }
    }
      
    public void ButtonActivationToggle(GameObject button, Collider2D collider)
    {
        bool tmp = false;
        tmp = button.activeInHierarchy ? false : true;
        button.SetActive(tmp);
        if (button.activeInHierarchy)
        {
            Debug.Log("This is the " + gameObject.collider.tag)
        }
    }  
