    using System;
    namespace ScoreBoardApp
    {
        // How a single scoreboard entry looks like.
        struct ScoreboardEntry
        {
            public ushort scoredPoints;
            public string playerName;
            public ScoreboardEntry( ushort points, string name )
            {
                scoredPoints = points;
                playerName = name;
            }
        }
        public class Program
        {
            // This is our scoreboard array. Most games start with fake entries,
            // to set some expectations, so are we. (Make sure you order them
            // correctly here and the data is clean and neat.)
            // To start empty use:
            // scoreboard = new ScoreboardEntry[10];
            private readonly ScoreboardEntry[] scoreboard = new [] {
                new ScoreboardEntry( 7777, "Winner" ),
                new ScoreboardEntry( 6666, "Hans" ),
                new ScoreboardEntry( 5555, "Anna" ),
                new ScoreboardEntry( 4444, "Sven" ),
                new ScoreboardEntry( 3333, "Elsa" ),
                new ScoreboardEntry( 2222, "Kurt" ),
                new ScoreboardEntry( 1111, "Ollie" ),
                new ScoreboardEntry(  999, "Bertha" ),
                new ScoreboardEntry(  888, "Joana" ),
                new ScoreboardEntry(  777, "Javaid" )
            };
            // What to show, when no player name given.
            private const string playerNamePlaceholder = "<none>";
            // In case we need to start from scratch.
            public void ClearBoard()
            {
                // We could just do (after we strip "readonly" from our field):
                //     scoreboard = new ScoreboardEntry[scoreboard.Length];
                // But this way we're re-using memory, and are still relatvely
                // fast:
                for (var i = 0; i < scoreboard.Length; i++)
                    scoreboard[i] = new ScoreboardEntry();
            }
            // This shows current state of the scoreboard (not very fast
            // nor efficient).
            public void PrintScoreboard()
            {
                Console.WriteLine("---+-----------------+-------");
                Console.WriteLine("{0,2} | {1,-15} | {2,6}", "#", "Name", "Score");
                Console.WriteLine("---+-----------------+-------");
                var len = scoreboard.Length;
                for (var i = 0; i < len; i++)
                    Console.WriteLine(
                        "{0,2:N0} | {1,-15} | {2,6:N0}",
                        i + 1,
                        scoreboard[i].playerName ?? playerNamePlaceholder,
                        scoreboard[i].scoredPoints
                    );
                Console.WriteLine("---+-----------------+-------");
            }
            // This checks if the player's score reached the scoreboard
            // tells us so, and if yes, then places his entry on the board.
            // Should be quite efficient & fast (apart from console output).
            public void RecordScore(ushort playerScore, string playerName)
            {
                // Cleaning the input data.
                if (playerName != null)
                {
                    // TODO: Deal with pesky control characters inside!
                    playerName = playerName.TrimStart();
                    playerName = playerName.Substring(0, Math.Min(15, playerName.Length)).TrimEnd();
                }
                if (string.IsNullOrWhiteSpace(playerName))
                    playerName = null;
                // Let's compare to the last scoreboard entry.
                var place = scoreboard.Length - 1;
                if (playerScore <= scoreboard[place].scoredPoints)
                {
                    Console.WriteLine(
                        "{0} did not make it with score {1:N0}",
                        playerName ?? playerNamePlaceholder,
                        playerScore
                    );
                    return;
                }
                // We'll go from bottom, to the top, to find correct landing
                // spot, and at the same time, move the beaten entries down.
                while (place > 0 && playerScore > scoreboard[place - 1].scoredPoints)
                {
                    place--;
                    scoreboard[place + 1] = scoreboard[place];
                }
                // Let's record our winner.
                scoreboard[place].scoredPoints = playerScore;
                scoreboard[place].playerName = playerName;
                Console.WriteLine(
                    "{0} is #{1:N0} with score {2:N0}",
                    playerName ?? playerNamePlaceholder,
                    place + 1,
                    playerScore
                );
            }
            // Let's play.
            public static void Main(string[] args)
            {
                var p = new Program();
                // Initial state.
                p.PrintScoreboard();
                // This player should not reach the board.
                p.RecordScore(666, null);
                p.PrintScoreboard();
                // This one scored same as the #10, which is not enough.
                p.RecordScore(777, "Almost there");
                p.PrintScoreboard();
                // This one should land as #5.
                p.RecordScore(4000, " Fifth ");
                p.PrintScoreboard();
                // This is the #1.
                p.RecordScore(ushort.MaxValue, "Best !!!!!!!!!!!!!!!!!!!!!!!");
                p.PrintScoreboard();
                // No app is considered worthy, without accepting some user
                // input. This one uses execution parameters.
                if (args.Length >= 1 && args.Length <= 2)
                {
                    ushort score = 0;
                    string name = null;
                    if (ushort.TryParse(args[0], out score))
                    {
                        if (args.Length > 1)
                            name = args[1];
                        p.RecordScore(score, name);
                        p.PrintScoreboard();
                    }
                    else
                        Console.Error.WriteLine("Give <score> and <name> as parameters.");
                }
                // Let's sweep everything before we go to sleep.
                p.ClearBoard();
                p.PrintScoreboard();
            }
        }
    }
