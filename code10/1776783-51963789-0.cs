    public GameObject areaContainer;
    public List<GameObject> MediumAreas = new List<GameObject>();
    private void Start()
    {
        DefineMediumAreas();
    }
    void DefineMediumAreas()
    {
        for (int i = 0; i < areaContainer.transform.childCount; i++)
        {
            var childGameObject = areaContainer.transform.GetChild(i).gameObject;
            if (childGameObject.name.StartsWith("area"))
                MediumAreas.Add(childGameObject);
        }
    }
