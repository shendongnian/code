    //an example of Polymorphism.
    class FamilyMembers //parent class
    {
        public virtual void GetData() //it's virtual method cuz it can be overridden later
        {
            Console.WriteLine("Family");
        }
    }
    class MyBrother : FamilyMembers //child class
    {
        public override void GetData() //the same method that we wrote before has been overridden
        {
            Console.WriteLine("Bro");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //here's what u asking about
            FamilyMembers myBrother = new MyBrother(); //MyBrother is a family member, the system now will choose the GetData() method from the child class MyBrother
            myBrother.GetData();
            Console.ReadLine();
        }
    }
