class Player
{
    public int id;
    public string name;
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi, enter how many players are playing");
        int numOfPlayer = int.Parse(Console.ReadLine());
        Player[] playerList = CreatePlayers(numOfPlayer);
        //What I'm trying to do! >>
        Console.WriteLine(playerList[0].name + "'s turn");
        Console.ReadKey();
    }
    static Player[] CreatePlayers(int amountOfPlayers)
    {
        Player[] playerList = new Player[amountOfPlayers];
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Console.WriteLine("Enter a name for player " + (i + 1));
            string playerName = Console.ReadLine();
            Player player = new Player();
            player.id = i;
            player.name = playerName;
            playerList[i] = player;
        }
        return playerList;
    }
}
