    public abstract class SuperHero
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Age { get; protected set; }
        public abstract KillEnemy(IEnemy e);
    }
    public class IronMan : SuperHero
    {
        public IronMan() : base()
        {
            FirstName = "Tony";
            LastName = "Stark";
            Age = 50;
        }
        public overrides KillEnemy(IEnemy e)
        {
            // Do what IronMan does to enemy  
        }
    }
