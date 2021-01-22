    static void Main(string[] args)
            {
            Employee e = new Employee();
            using (Parent p = new Parent("test.txt"))
            {
                
                e.Parent = p;
                
           
              using ( System.IO.StreamWriter fileWriter  = 
                    new System.IO.StreamWriter(e.Parent.File))
                    {
                    fileWriter.WriteLine("Betsy");
                }
            }
        
       using (System.IO.StreamWriter fileWriter =
               new System.IO.StreamWriter(e.Parent.File))
            {
                fileWriter.WriteLine("Betsy"); //uh-oh
            }
            Console.ReadLine();
        }
        public class Employee
        {
            public Parent Parent;
        }
        public class Parent : IDisposable
        {
            public System.IO.FileStream File;
            public Parent(string fileName)
            {
                File = System.IO.File.Open(fileName, System.IO.FileMode.OpenOrCreate);
            }
            public void Dispose()
            {
                ((IDisposable)File).Dispose(); //or File.Close();
            }
        }
