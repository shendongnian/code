    List<string> MyList = new List<string>();
    
    void Start()
    {
        MyList.Add("SampTable");
        MyList.Add("Respawn");
        MyList.Add("SampTable");
    }
    
    public void ReadList()
    {
        int TagNum = MyList.Count;
        Debug.Log(TagNum);
        for (int i = 0; i < TagNum; i++)
        {
            Debug.Log(MyList[i]);
        }
    }
