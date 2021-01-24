    ScriptFromYourQuestion yourInstancingSript;
    
    void Start()
    {
        GameObject obj = GameObject.Find("NameOfObjectScriptInYourQuestionIsAttachedTo");
        yourInstancingSript = obj.GetComponent<ScriptFromYourQuestion>();
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        //Detect if we collided with the boundary
        if (other.CompareTag("Player"))
        {
            //Remove Self/barrier from the List
            yourInstancingSript.spawning.Remove(this.gameObject);
    
    
            //Delete Self/barrier 
            Destroy(this.gameObject);
        }
    }
