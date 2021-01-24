    class Program
    {
        static void Main(string[] args)
        {
            var xml = System.IO.File.ReadAllText(@"C:\Users\Nullplex6\source\repos\ConsoleApp4\ConsoleApp4\Files\XMLFile9.xml");
            var serializer = new XmlSerializer(typeof(Lookupdb));
            using (var reader = new StringReader(xml))
            {
                Lookupdb lookupdb = (Lookupdb)serializer.Deserialize(reader);
                //Here you can get any xml node and attribute value of single "RentalSession" in "Sessions" by passig id to where clause
                RentalSession rentalSession = lookupdb.Sessions.RentalSession.Where(x => x.Id == "68a6b485-d30a-439a-8081-8c09f724d23b").FirstOrDefault();
                Console.WriteLine("Id: " + rentalSession.Id);
                Console.WriteLine("VehicleRefId: " + rentalSession.VehicleRefId);
                Console.WriteLine("EndDate: " + rentalSession.RentalPeriod.EndDate);
                Console.WriteLine("VehicleGroup: " + rentalSession.VehicleGroup);
                Console.WriteLine();
                //Here you can get any xml node and attribute value of single "Reference"  in "References" by passig id to where clause
                Reference reference = lookupdb.References.Reference.Where(x => x.Id == "d1053bd3-a1cb-4fb4-a7d5-ffee3e10ffdb").FirstOrDefault();
    
                Console.WriteLine("OwnerName: " + reference.OwnerName);
                Console.WriteLine("Engineer: " + reference.Engineers.Engineer);
                Console.ReadLine();
            }
        }
    }
