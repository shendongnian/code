    public Transform prefabToCreate;
    void Update() {
       if(Input.GetMouseButtonDown(0)) {
          Instantiate(prefabToCreate, Input.mousePosition, Quaternion.identity);
       }
     }
