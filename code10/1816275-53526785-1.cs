    public class MainClass
    {
        public static void Main()
        {
            //This is a instance of SuperHero, specific, Tony Stark
            SuperHero ironman = new SuperHero("Tony","Stark",50);
            Console.WriteLine(ironman.FirstName);
                        //This is a instance of SuperHero, specific, Steve Rogers
            SuperHero captain = new SuperHero("Steve","Rogers",126);
            Console.WriteLine(captain.FirstName);
        }
    }
