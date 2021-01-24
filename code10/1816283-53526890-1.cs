       public class MainClass
        {
            public static void Main()
            {
                Avenger CaptainAmerica = new Avenger("Steve", "Rogers", 126);
                Avenger IronMan = new Avenger ("Tony", "Stark", 50);
                Console.WriteLine(CaptainAmerica.fName); // Steve
                Console.WriteLine(IronMan.fName); // Tony
                
            }  
        }
    public class Avenger
    {
        public string fName {get; set;};
        public string lName {get; set;};
        public int Age {get; set;};
        Public Avenger (string fname, string lname, int age){
              this.fName = fname;
              this.lName = lname;
              this.Age = age;
        }
    }
