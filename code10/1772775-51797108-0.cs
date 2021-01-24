    class MainApp
    {
        static void Main()
        {
            Cat cat = new Cat(4, "Black", true, "White");
            Tiger tiger = new Tiger(4, "Black", true, "Yellow");
            Cow cow = new Cow(4, "Black", true, "Black");
        }
    }
    public class Animal
    {
        public int Legs { get; set; }
        public string EyeColour { get; set; }
        public bool Tail { get; set; }
        public string SkinColour { get; set; }
        public Animal(int legs, string eyeColour, bool tail, string skinColour)
        {
            this.Legs = legs;
            this.EyeColour = eyeColour;
            this.Tail = tail;
            this.SkinColour = skinColour;
        }
    }
    public class Cat : Animal
    {
        public Cat(int legs, string eyeColour, bool tail, string skinColour) 
            : base(legs, eyeColour, tail, skinColour)
        {
        }
        public int MyPropertyCat { get; set; }
    }
    public class Tiger : Animal
    {
        public Tiger(int legs, string eyeColour, bool tail, string skinColour) 
            : base(legs, eyeColour, tail, skinColour)
        {
        }
        public int MyPropertyForTiger { get; set; }
    }
    public class Cow : Animal
    {
        public Cow(int legs, string eyeColour, bool tail, string skinColour)
            : base(legs, eyeColour, tail, skinColour)
        {
        }
        public int MyPropertyForCow { get; set; }
    }
}         
   
