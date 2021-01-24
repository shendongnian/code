    BoxCollider boxCol;
    
    void Awake(){
        boxCol = otherGameObject.GetComponent<BoxCollider>();
    }
    void Start(){
        //Here you set the size of the collider
        boxCol.size = new Vector3(2,2,2);
    }
    
