    public class Race
    {
        int Year { get; set; }
        Track Track { get; set; }
        Driver[] Placings { get; set; }
        public int this[Driver driver] { } // placing by driver
    }
    public class Results
    {
        YearResults this[int index] { }
        DriverResults this[Driver index] { }
        TrackResults this[Track index] { }
        ConstructorResults this[Constructor index] { }
    }
    public class YearResults
    {
        YearDriverResults this[Driver index] { }
    }
