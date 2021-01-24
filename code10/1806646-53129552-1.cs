    static void Main(string[] args)
    {
        //here you wanna declare test as " r"
        string test = " r";
        while (!test[1].Equals('r'))
        {
            var privateKey = new Key(); // generate a random private key
            var publicKey = privateKey.PubKey;
            var Address_testnet = publicKey.GetAddress(Network.TestNet);
            //Remove "string" keyword in front of test
            test = Convert.ToString(Address_testnet); 
        }
        Console.WriteLine("public address is {0}", test);
    }
