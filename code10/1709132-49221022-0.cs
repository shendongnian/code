    public class CPet 
    {
        public string Name;
        public DateTime LastFed;
        ...
    }
    static void hungerDecrease(CPet pet)
    {
        if (DateTime.Now > pet.LastFed.AddHours(4))
        {
            pet.Hunger -= 1;
            pet.LastFed = DateTime.Now;
        }
    }
