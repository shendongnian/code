        class Program
    {
        static void Main(string[] args)
        {
            string[,] initialize = { { "building", "A-51" }, { "apartment", "210" }, {"wow", "nerf Druids"}};
            
            MyHashTable myhashTable = new MyHashTable(initialize);
            Console.WriteLine(myhashTable["building"].ToString());
            Console.WriteLine(myhashTable["apartment"].ToString());
            Console.WriteLine(myhashTable["wow"].ToString());
            Console.ReadKey();
          
        }
    }
