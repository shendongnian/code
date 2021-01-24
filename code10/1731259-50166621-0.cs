     public class Journey
        {
            public decimal Distance { get; set; }
            public DateTime JourneyDate { get; set; }
        }
        public class Drivers
        {
            public string Name { get; set; }
            public Journey Journey { get; set; }
        }
        public class  DistanceCovered
        {
            public DateTime JourneyDate { get; set; }
            public decimal TotalDistance { get; set; }
        }
