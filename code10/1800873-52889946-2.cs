    List<GameObject> models = new List<GameObject>;
    public GameObject baseModel; //Your model
    private void CreateModel()
    {
       GameObject obj = GameObject.Instantiate(baseModel) as GameObject;
       models.Add(obj);
    }
