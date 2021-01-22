    internal interface Mammal
    {
        string Speek();
    }
    internal class Person : Mammal
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        
        public string Speek()
        {
            return "My DOB is: " + DOB.ToString() ;
        }
    }
    internal class Dog : Mammal
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Speek()
        {
            return "Woff!";
        }
    }
