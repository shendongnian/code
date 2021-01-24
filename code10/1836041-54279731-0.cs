    interface IThief
    {
        void Steal();
    }
    public class Goblin : IEnemy, IThief
    {
        public int Health { get; set; }
        public Goblin()
        {
            Health = 50;
            Console.WriteLine("You encounter an Enemy Goblin!");
        }
        public void Steal()
        {
            //TODO: steal
        }
    }
