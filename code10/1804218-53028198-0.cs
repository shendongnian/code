    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Timers;
    
    namespace Sandbox
    {
        public class Player
        {
            public string PlayerName { get; set; }
        }
    
        public class Program
        {
            public static Player _currentTurn;
            public static bool _isGameOver;
            public static System.Timers.Timer _gameTimer;
    
            static void Main(string[] args)
            {
                _gameTimer = new System.Timers.Timer(10000);
                _gameTimer.Elapsed += _gameTimer_Elapsed;
    
                var players = new List<Player>()
                {
                    new Player() { PlayerName = "Player1" },
                    new Player() { PlayerName = "Player2" },
                    new Player() { PlayerName = "Player3" }
                };
    
                _gameTimer.Start();
    
                while (!_isGameOver)
                {
                    foreach (var player in players)
                    {
                        _currentTurn = player;
    
                        PlayTurn();
                    }
                }
    
                Console.WriteLine("Game Over!");
            }
    
            private static void _gameTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                _isGameOver = true;
                _gameTimer.Stop();
            }
    
            public static void PlayTurn()
            {
                Console.WriteLine($"{_currentTurn.PlayerName} took their turn.");
                Thread.Sleep(1000);
            }
        }
    }
