    using System;
    
    namespace NamedTuple
    {
        class Program
        {
            static void Main(string[] args)
            {
                MobileObject[] mobileObjects = new MobileObject[3];
                // insert MobileObject
                MobileObject mob1 = new MobileObject()
                {
                    Name = "Jawahara",
                    Position = (12, 15),
                    Id = 123456
                };
                mobileObjects[0] = mob1;
    
                //Insert Vehicle
                Vehicle veh = new Vehicle()
                {
                    Name = "Willow",
                    Position = (14, 13),
                    Id = 6549879,
                    Length = 23
                };
                mobileObjects[1] = veh;
    
                //Insert another vehicle
                mobileObjects[2] = new Vehicle()
                {
                    Name = "Indira",
                    Position = (14, 13),
                    Id = 885298451,
                    Length = 12
                };
    
                foreach (var mobileObject in mobileObjects)
                {
                    Console.WriteLine($"Name: {mobileObject.Name}, " +
                        $"Position: {mobileObject.Position.X };{mobileObject.Position.Y}, " +
                        $"Id: {mobileObject.Id}");
    
                    if(mobileObject is Vehicle)
                    {
                        Console.WriteLine($"Length: {((Vehicle)mobileObject).Length}");
                    }
                }
            }
        }
    
        public class MobileObject
        {
            public string Name { get; set; }
            public (int X, int Y) Position { get; set; }
            public int Id { get; set; }
        }
    
        public class Vehicle : MobileObject
        {
            public int Length { get; set; }
        }
    }
