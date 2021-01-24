    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[{ 'AnimalName' : 'Gatto', 'Year' : 5.0 }, { 'AnimalName' : 'Gatto', 'Year' : 6.0 }]";
            JToken jToken = JToken.Parse(json);                         //Point No. 1
            List<Animali> animalis = jToken.ToObject<List<Animali>>();  //Point No. 2
            foreach (Animali animali in animalis)  //Print result
            {
                Console.WriteLine("AnimalName: " + animali.AnimalName + "\t Year: " + animali.Year);
            }
            Console.ReadLine();
        }
    }
    
