            //Use respective attributes 
            public class KMessage
            {
                public string Project { get; set; }
                public string Ref { get; set; }
                public float Latitude { get; set; }
                public float Longitude { get; set; }
                //I guess here is the problem, instead of array you can use list
                public Parklist[] ParkList { get; set; } 
            }
    
            public class Parklist
            {
                public string Id { get; set; }
                public int State { get; set; }
                public DateTime DateTime { get; set; }
            }
