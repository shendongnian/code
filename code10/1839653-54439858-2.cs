    Dictionary<string, Item> dict = null;
    void Start(){
        string str = GetJson(); // However you get it
        RootObject ro = JsonUtility.FromJson<RootObject>(str);
        this.dict = new Dictionary<string,Item>();
        foreach(Item item in ro.items){
            Item temp = temp;
            this.dict.Add(item.Id, temp);
        }
        ro = null;
    }
