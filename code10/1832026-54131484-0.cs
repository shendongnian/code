    namespace GYA.HW4.OOP.Classes.Classes 
    {
        public class Worker 
        {
            public static readonly string[] AllRanks => new [] { "Неопытный", "Опытный", "Мастер" };
            
            public string Rank { get; internal set; }
        }
    }
