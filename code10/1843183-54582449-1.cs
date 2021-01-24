    public GameObject hintBoxContainer;
    private List<GameObject> hintBoxes = new List<GameObject>();
    private void Start(){
      for(int i =0; i < hintBoxContainer.transform.childCount; i++){
        hintBoxes.Add(hintBoxContainer.transform.getChild(i).gameObject);
      }
    }
    private void Update(){
      if(PPLChoiceMade == 1){
        //Since we know the first hintbox is at the index of 0
        for(int i =0; i < hintBoxes.Count; i++){
          if(i == 0){
            hintBox[i].SetActive(true);
          }else{
            hintBox[i].SetActive(false);
          }
        }
      }
    }
