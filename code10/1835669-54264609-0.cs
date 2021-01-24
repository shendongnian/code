    public class DaysDetails
    {
        public bool Sun {get;set;}
        public bool Mon {get;set;}
        ...
        public bool Sat {get;set;} //All 7 days of the week
        public override string ToString() {
            //formatted string
            return $"{GetNumberRepresentationOfBool(Sun)},{GetNumberRepresentationOfBool(Mon)},{GetNumberRepresentationOfBool(Sat)}"
        }
    }
    public int GetNumberRepresentationOfBool(bool value) {
        return value ? 1 : 0
    }
    //printing the value
    Console.WriteLine(dayDetailsObject.ToString());
