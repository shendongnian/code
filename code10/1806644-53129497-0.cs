    static void Main(string[] args)
        {
    
            string test = "";
    
            while (!test[1].Equals('r'))
            {
                var privateKey = new Key(); // generate a random private key
                var publicKey = privateKey.PubKey;
                var Address_testnet = publicKey.GetAddress(Network.TestNet);
                test = Convert.ToString(Address_testnet); 
            }
    
            Console.WriteLine("public address is {0}", test);
    
        }
