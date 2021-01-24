    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
    
        public class Program
        {
            public static void Main(string[] args)
            {
                Bird b = new Bird();
                b.SetName("Tweety");
                b.Chirp();
    
                Bird b2 = new Bird();
                b2.SetName("Woody");
                b2.Chirp();
    
                Console.ReadLine();
            }
        }
        public class Bird
        {
            private string name;
            private double weight = 30.5d;
    
            public void SetName(string newName)
            {
                if (newName != null && newName.Length > 2)
                {
                    System.Console.WriteLine("Bird already has a name");
                    this.name = newName;
                }
                else if (newName.Length < 3)
                {
                    System.Console.WriteLine("New name must be longer than two chars");
                }
                else
                {
                    name = newName;
                }
            }
    
            public string GetnewName()
            {
                return this.name;
            }
    
            public void Chirp()
            {
                System.Console.WriteLine(name + " says chirp!");
            }
        }
    }
