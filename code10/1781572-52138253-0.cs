    public struct myCustomType
    {
        private readonly string name;
        private readonly bool flag;
        
        public string Name => name;
        public bool Flag => flag;
        public myCustomType(string name, bool flag)
        {
            this.name = name;
            this.flag = flag; 
        }
    }
    public Dictionary <int , myCustomType> Teams=new Dictionary<int,myCustomType>();
    private ExitGames.Client.Photon.Hashtable m_PlayerCustomPropeties = new ExitGames.Client.Photon.Hashtable();
    private void addTeams()
    {
        Teams.Add(1, new myCustomType("Yellow", true));
        Teams.Add(2, new myCustomType("Red", true));
        Teams.Add(3, new myCustomType("Blue", true));
        Teams.Add(4, new myCustomType("Green", true));
        //...
    }
