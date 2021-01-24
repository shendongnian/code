    public class MyGame
    {
        public static void Main(string[] args) // Here our Exe-Args are delivered to our program..
        {
            // Some dummycode to show what is done with your Args..
            if (args != null && args.Length > 0)
            {
                string server = args.Where(a => a.StartsWith("-connect")).Select(s => s.Split(':').Last()).FirstOrDefault();
                if (server != null)
                    ConnectToServer(server); // when starting with a "-connect" your game is stuck in this method.
            }
            // this will not be executed, because we are alread in the game, after "ConnectToServer()"
            ShowGameIntro();
            StartMainMenu();
        }
    }
