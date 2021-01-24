    class PlayerData
    {
        public int _dataParameter;
        public PlayerData(int parameter)
        {
            _dataParameter = parameter;
        }
        protected PlayerData(PlayerData pd)
        {
            _dataParameter = pd._dataParameter;
        }
    }
    class Player : PlayerData
    {
        public int _playerParameter;
        public Player(int a, PlayerData pd) : base(pd)
        {
            _playerParameter = a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new PlayerData(1);
            var p = new Player(2, pd);
            Console.WriteLine("Player {0}, base {1}", p._playerParameter, p._dataParameter);
            Console.ReadKey();
        }
    }
