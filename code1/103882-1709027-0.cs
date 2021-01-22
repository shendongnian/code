    class Program
    {
        [DataContract]
        public class Person
        {
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            public override string ToString()
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
        static void Main(string[] args)
        {
            var person = new Person { FirstName = "Joe", LastName = "Schmo" };
            var message = System.ServiceModel.Channels.Message.CreateMessage(MessageVersion.Default, "action", person);
            var reader = message.GetReaderAtBodyContents();
            var newMessage = System.ServiceModel.Channels.Message.CreateMessage(MessageVersion.Default, "newAction", reader);
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine(newMessage);
            Console.WriteLine();
            Console.WriteLine(newMessage.GetBody<Person>());
            Console.ReadLine();
        }
    }
