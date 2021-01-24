    public class MyContext : DbContext
    {
        public DbSet<Zombie> Zombies { get; set; }
        public DbSet<Human> Humans { get; set; }
    }
