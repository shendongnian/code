    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("demo.json"); //Your json here
            RequestResult requestResult = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestResult>(json); //There is your result
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
    class RequestResult
    {
        public AppointmentType[] appointment_types;
        public int total_entries;
        public Link links;
    }
    class Practitioners
    {
        public Link links;
    }
    class BillableItem
    {
        public Link links;
    }
    class Link
    {
        public string self;
    }
    class AppointmentType
    {
        public int id;
        public int max_attendees;
        public string name;
        public BillableItem billable_item;
        public Practitioners practitioners;
    }
