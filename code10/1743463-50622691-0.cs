    [SerializeField] GameObject dialogueObject; //here drag the canvas
    [SerializeField] GameObject text; //we will get its component for changing the text later on
    void Start(){
       text = GetComponent<Text>().text = "Sample Dialogue";
       dialogueObject.setActive(false);
    }
    
    void OnCollisionEnter(collision collide){
        if(collide.gameObject.name == "NPC"){
            dialogue.setActive(true);
        }
    }
