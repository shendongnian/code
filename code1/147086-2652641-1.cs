    public class Player
    {
        private readonly string _name;
        private readonly string _surname;
        private readonly int _score;
        private string _nickName = "";
        public Player(string name, string surname, int score)
        {
            _name = name;
            _surname = surname;
            _score = score;
        }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_nickName)) return string.Format("{0} {1}", _name, _surname);
                else return string.Format("{0} \"{1}\" {2}", _name, _nickName, _surname);
            }
        }
        public int Score
        {
            get { return _score; }
        }
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }
    }
    public delegate bool PlayerHandlerDelegate(Player player);
    public class HandlersChain
    {
        private readonly List<PlayerHandlerDelegate> _chain = new List<PlayerHandlerDelegate>();
        public void AddHandler(PlayerHandlerDelegate handler)
        {
            _chain.Add(handler);
        }
        public void HandlePlayer(Player player)
        {
            foreach (PlayerHandlerDelegate handler in _chain)
            {
                if (handler(player)) break;
            }
        }
    }
    class Program
    {
        static PlayerHandlerDelegate CreateHandlerDelegate(string position, int minScore)
        {
            return delegate(Player p)
                    {
                        if (p.Score > minScore)
                        {
                            //MessageBox.Show(string.Format("{0} is greeted by {1}", p.FullName, position));
                            Console.WriteLine(string.Format("{0} is greeted by {1}", p.FullName, position));
                            return true;
                        }
                        return false;
                    };
        }
        static void Main(string[] args)
        {
            Player p1 = new Player("John", "Smith", 100);
            Player p2 = new Player("William", "Brown", 170);
            Player p3 = new Player("Robert", "Johns", 500);
            HandlersChain chain = new HandlersChain();
            chain.AddHandler(delegate(Player p)
                                {
                                    if (p.Score > 400)
                                    {
                                        p.NickName = "The Hero";
                                    }
                                    return false;
                                });
            chain.AddHandler(CreateHandlerDelegate("Manager", 300));
            chain.AddHandler(CreateHandlerDelegate("Supervisor", 200));
            chain.AddHandler(CreateHandlerDelegate("Employee", 100));
            chain.AddHandler(delegate(Player p)
                {
                    if (p.Score <= 100)
                    {
                        //MessageBox.Show(string.Format("{0} got low score", p.FullName));
                        Console.WriteLine(string.Format("{0} got low score", p.FullName));
                        return true;
                    }
                    return false;
                });
            chain.HandlePlayer(p1);
            chain.HandlePlayer(p2);
            chain.HandlePlayer(p3);
        }
    }
