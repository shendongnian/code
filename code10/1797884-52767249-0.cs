    class Program {
        static void Main (string[] args) {
            // Create Object
            Account account = new Account {
                Id = 100,
                Name = "Berkay"
            };
            // You can use BinaryFormatter 
            IFormatter formatter = new BinaryFormatter ();
            Stream stream = new FileStream ("D:\\account.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize (stream, account);
            stream.Close ();
            stream = new FileStream ("D:\\account.txt", FileMode.Open, FileAccess.Read);
            Account readAccount = formatter.Deserialize(stream) as Account;
            System.Console.WriteLine(readAccount.Id);
            System.Console.WriteLine(readAccount.Name);
            Console.ReadLine();
        }
    }
        // Serializable attribute
        [Serializable]
        public class Account {
        public int Id { get; set; }
        public string Name { get; set; }
    }
