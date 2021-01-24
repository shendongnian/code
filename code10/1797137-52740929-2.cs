    class Program
    {
        static void Main(string[] args)
        {
            var xml = System.IO.File.ReadAllText(@"C:\Users\xxx\source\repos\ConsoleApp4\ConsoleApp4\Files\XMLFile9.xml");
            var serializer = new XmlSerializer(typeof(Lookupdb));
            using (var reader = new StringReader(xml))
            {
                Lookupdb lookupdb = (Lookupdb)serializer.Deserialize(reader);
                //Here you can get any xml node and attribute value in "Sessions"
                Console.WriteLine("Id: " + lookupdb.Sessions.RentalSession.Id);
                Console.WriteLine("VehicleRefId: " + lookupdb.Sessions.RentalSession.VehicleRefId);
                Console.WriteLine("EndDate: " + lookupdb.Sessions.RentalSession.RentalPeriod.EndDate);
                Console.WriteLine("VehicleGroup: " + lookupdb.Sessions.RentalSession.VehicleGroup);
                //Here you can get any xml node and attribute value in "References"
                Console.WriteLine("OwnerName: " + lookupdb.References.Reference.OwnerName);
                Console.WriteLine("Engineer: " + lookupdb.References.Reference.Engineers.Engineer);
                Console.ReadLine();
            }
        }
    }
