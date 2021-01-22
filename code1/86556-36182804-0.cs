    public class Professor
    {
        public string _Name;
    
        public Professor(){}
    
        public Professor(string name)
        {
            _Name=name;
        }
    
        public void Display()
        {
            Console.WriteLine("Name={0}",_Name);
        }
    }
    
    public class Example
    {
        static int Main(string[] args)
        {
            Professor david = new Professor("David");
    
            Console.WriteLine("\nBefore calling the method ProfessorDetails().. ");
            david.Display();
            ProfessorDetails(ref david);
            Console.WriteLine("\nAfter calling the method ProfessorDetails()..");
            david. Display();
        }
    
        static void ProfessorDetails(ref Professor p)
        {
            //change in the name  here is reflected 
            p._Name="Flower";
    
            //Why  Caller unable to see this assignment 
            p=new Professor("Jon");
        }
    }
