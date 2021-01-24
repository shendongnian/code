    namespace NatesFirstTextGame
    {
        class Program
        {
            static void Main(string[] args)
            {
                Goose goose = new Goose();
                goose.GooseStats();
                goose.GetEnemyEnmName();
                Console.WriteLine(goose.GetEnemyEnmName());
                Console.WriteLine(goose.GetEnemyEnmStr());
            }
        }
    }
