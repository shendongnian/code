    public class Enemy
    {
        public void AimAt(Enemy opponent)
        {
            Console.WriteLine($"{Name} is aiming at {opponent.Name}");
            opponent.AimedAt(this);
        }
        private void AimedAtBy(Enemy opponent)
        {
            // update trust between this and opponent
            Console.WriteLine($"{Name} trusts {opponent.Name} less because they are pointing a gun at them!");
        }
    }
