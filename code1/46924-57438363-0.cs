    public class Auto 
    { 
        public string Make {get; set;}
        public string Model {get; set;}
    }
    public class Sedan : Auto
    { 
        public int NumberOfDoors {get; set;}
    }
    public static T ConvertAuto<T>(Sedan sedan) where T : class
    {
        object auto = sedan;
        return (T)loc;
    }
