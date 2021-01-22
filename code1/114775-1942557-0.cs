    class Account
    {
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        internal void Serialize(BinaryWriter bw)
        {
            // Add logic to serialize everything you need here
            // Keep in synch with Deserialize
            bw.Write(AccountName);
            bw.Write(AccountNumber);
        }
        internal void Deserialize(BinaryReader br)
        {
            // Add logic to deserialize everythin you need here, 
            // Keep in synch with Serialize
            AccountName = br.ReadString();
            AccountNumber = br.ReadInt32();
        }
    }
    class Program
    {
        static void Serialize(string OutputFile)
        {
            // Write to disk 
            using (Stream stream = File.Open(OutputFile, FileMode.Create))
            {
                BinaryWriter bw = new BinaryWriter(stream);
                // Save number of entries
                bw.Write(accounts.Count);
                foreach (KeyValuePair<string, List<Account>> accountKvp in accounts)
                {
                    // Save each key/value pair
                    bw.Write(accountKvp.Key);
                    bw.Write(accountKvp.Value.Count);
                    foreach (Account account in accountKvp.Value)
                    {
                        account.Serialize(bw);
                    }
                }
            }
        }
        static void Deserialize(string InputFile)
        {
            accounts.Clear();
            // Read from disk
            using (Stream stream = File.Open(InputFile, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(stream);
                int entryCount = br.ReadInt32();
                for (int entries = 0; entries < entryCount; entries++)
                {
                    // Read in the key-value pairs
                    string key = br.ReadString();
                    int accountCount = br.ReadInt32();
                    List<Account> accountList = new List<Account>();
                    for (int i = 0; i < accountCount; i++)
                    {
                        Account account = new Account();
                        account.Deserialize(br);
                        accountList.Add(account);
                    }
                    accounts.Add(key, accountList);
                }
            }
        }
        static Dictionary<string, List<Account>> accounts = new Dictionary<string, List<Account>>();
        static void Main(string[] args)
        {
            string accountName = "Bob";
            List<Account> newAccounts = new List<Account>();
            newAccounts.Add(AddAccount("A", 1));
            newAccounts.Add(AddAccount("B", 2));
            newAccounts.Add(AddAccount("C", 3));
            accounts.Add(accountName, newAccounts);
            accountName = "Tom";
            newAccounts = new List<Account>();
            newAccounts.Add(AddAccount("A1", 11));
            newAccounts.Add(AddAccount("B1", 22));
            newAccounts.Add(AddAccount("C1", 33));
            accounts.Add(accountName, newAccounts);
            string saveFile = @"C:\accounts.bin";
            Serialize(saveFile);
            // clear it out to prove it works
            accounts.Clear();
            Deserialize(saveFile);
        }
        static Account AddAccount(string AccountName, int AccountNumber)
        {
            Account account = new Account();
            account.AccountName = AccountName;
            account.AccountNumber = AccountNumber;
            return account;
        }
    }
