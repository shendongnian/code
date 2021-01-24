    class Animal
    {
        public int[,] RandomDataGen()
        {
            int[,] Dogs = new int[1, 2];
            // And the rest of the code is the same here
            return Dogs;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {    
            Animal dataAnimal = new Animal();
            int[,] Dogs = dataAnimal.RandomDataGen();
            
            // And the rest of the code is the same here
        }
    }
