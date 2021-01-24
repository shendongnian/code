    class Program
        {
            static void Main(string[] args)
            {
                Product p = new Product()
                {
                    ID = 1,
                    Name = "Mango"
                };
                Message m=Message.CreateMessage(MessageVersion.Soap12, "mymessage", p);
                MessageHeader hd = MessageHeader.CreateHeader("customheader", "mynamespace", 100);
                m.Headers.Add(hd);
                Console.WriteLine(m);
            }
        }
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
    }
