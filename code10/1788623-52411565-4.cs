    void Start()
    {
        for(int i = 0 ; i < 100; i++)
        {
             GameObject btn = Instantiate<GameObject>(btnPrefab);
             GameObject target = GetTarget();
             btn.GetComponent<Button>().onClick.AddListener(()=>
             {
                 Method(target);
             });
        }
    }
    void Method(GameObject obj)
    {
        Debug.Log(obj.name);
    }
