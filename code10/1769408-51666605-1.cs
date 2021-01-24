    public interface IFamily //the Parent Class
    {
        //an interface holds the signature of it's child properties and methods but don't set values
        //Some properties signatures
        int Age { get; set; }
        string Name { get; set; }
        //some methods
        void PrintData();
    }
    public class MyBrother : IFamily //Child class that inherits from the parent class
    {
        //some properties, methods, fields
        
        public string Name { get; set; } //public required
        public int Age { get; set; } //public required
        private string Collage { get; set; } //for my brother only 
        //constractor that sets the default values when u create the class
        public MyBrother()
        {
            Name = "Cody";
            Age = 20;
            Collage = "Faculty of engineering";
        }
        ////a method
        void IFamily.PrintData()
        {
            Console.WriteLine("Your name is: " + Name + " and your age is: " + Age + " and you collage is: " + Collage);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //now let's try to call the the methods and spawn the child classes :)
            //spawn the child class (MyBrother) that inherits from the Family interface
            //this is the answer of ur question
            IFamily myBrother = new MyBrother(); // the constructor will auto-set the data for me so i don't need to set them
            //printing the dude
            myBrother.PrintData();
            Console.ReadLine();  
        }
    }
