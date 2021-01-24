     class Player
    {
        public int id {get;set;}
        public string name{get;set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, enter how many players are playing");
            int numOfPlayer = int.Parse(Console.ReadLine());
            List<Player> playerList = CreatePlayers(numOfPlayer);
            //What I'm trying to do! >>
            Console.WriteLine(playerList.ElementAt(0).name + "'s turn");
            Console.ReadLine();
        }
       static List<Player> CreatePlayers(int amountOfPlayers)
        {
            List<Player> playerList = new List<Player>();
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine("Enter a name for player " + (i + 1));
                string playerName = Console.ReadLine();
                Player player = new Player();
                player.id = i;
                player.name = playerName;
                playerList.Add(player);
            }
            return playerList;
        }
    }
