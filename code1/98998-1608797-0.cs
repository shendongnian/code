    using System;
    using ADOX;
    
    namespace ConsoleProgram1
    {
        public class ConsoleProgram1
        {
    
            public static void Main(string[] args)
            {
    
                  Catalog cat = new Catalog();
    
                  cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                     "Data Source=D:\AccessDB\NewMDB.mdb;" & _
                     "Jet OLEDB:Engine Type=5");
    
                  Console.WriteLine("Database Created Successfully")
    
            }
    
        }
    }
