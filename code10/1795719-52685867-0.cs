    void Main()
    {
        Start();
        ReadList();
    }
    
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
        Console.WriteLine(TagNum);
        for (int i = 0; i < TagNum; i++)
        {
            Console.WriteLine(MyList[i]);
        }
    }
