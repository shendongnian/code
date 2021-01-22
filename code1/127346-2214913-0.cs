    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Message
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("input.xml");
            var messages = doc.Descendants("Message")
                .Select(element => new Message
                {
                    Text = element.Element("messagetext").Value,
                    Date = DateTime.ParseExact(element.Element("date").Value, "MM.dd.yyyy", null)
                }).OrderBy(message => message.Date);
            foreach (Message message in messages)
            {
                Console.WriteLine("{0} : {1}", message.Date, message.Text);
            }
        }
    }
