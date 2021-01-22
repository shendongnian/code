    public interface IDataProvider
    {
        IOnlinePokerInfo ParseFileInformation(FileInfo input);
    }
    public interface IOnlinePokerInfo
    {
        int Hand { get; set; }
        DateTime DateInfo { get; set; }
        List<IPlayer> Players { get; set; }
        void ProcessInformation();
    }
    public interface IPlayer
    {
        string Name { get; set; }
    }
    public class MyOnlinePokerInfo : IOnlinePokerInfo
    {
        private int hand;
        private DateTime date;
        private List<IPlayer> players;
        public int Hand { get { return hand; } set { hand = value; } }
        public DateTime DateInfo { get { return date; } set { date = value; } }
        public List<IPlayer> Players { get { return players; } set { players = value; } }
        public MyOnlinePokerInfo(int hand, DateTime date)
        {
            this.hand = hand;
            this.date = date;
            players = new List<IPlayer>();
        }
        public MyOnlinePokerInfo(int hand, DateTime date, List<IPlayer> players)
            : this(hand, date)
        {
            this.players = players;
        }
        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }
        public void ProcessInformation()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder("Hand #: " + hand + " Date: " + date.ToLongDateString());
            info.Append("\nPlayers:");
            foreach (var s in players)
            {
                info.Append("\n"); 
                info.Append(s.Name);
            }
            return info.ToString();
        }
    }
    public class MySampleProvider1 : IDataProvider
    {
        public IOnlinePokerInfo ParseFileInformation(FileInfo input)
        {
            MyOnlinePokerInfo info = new MyOnlinePokerInfo(1, DateTime.Now);
            IPlayer p = new MyPlayer("me");
            info.AddPlayer(p);
            return info;
        }
    }
    public class MySampleProvider2 : IDataProvider
    {
        public IOnlinePokerInfo ParseFileInformation(FileInfo input)
        {
            MyOnlinePokerInfo info = new MyOnlinePokerInfo(2, DateTime.Now);
            IPlayer p = new MyPlayer("you");
            info.AddPlayer(p);
            return info;
        }
    }
    public class MyPlayer : IPlayer
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public MyPlayer(string name)
        {
            this.name = name;
        }
    }
    public class OnlinePokerInfoManager
    {
        static void Main(string[] args)
        {
            List<IOnlinePokerInfo> infos = new List<IOnlinePokerInfo>();
            MySampleProvider1 prov1 = new MySampleProvider1();
            infos.Add(prov1.ParseFileInformation(new FileInfo(@"c:\file1.txt")));
            MySampleProvider2 prov2 = new MySampleProvider2();
            infos.Add(prov2.ParseFileInformation(new FileInfo(@"c:\file2.log")));
            foreach (var m in infos)
            {
                m.ProcessInformation();
            }
        }
    }
