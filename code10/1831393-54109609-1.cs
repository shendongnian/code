    class Program
    {
        static void Main(string[] args)
        {
          while(true) { //run forever, we'll break out if the user wants to quit
            Console.WriteLine("What is the Height of the Painting?");
    
            string input = Console.ReadLine();
            int height;
          
    
            if ("int.TryParse(input, out height))
            {
                Console.WriteLine("Invalid number. Please make it an integer... e.g 1-9");
            }
            else
            {
                Console.WriteLine("What is the Width of the Painting?");
                string input2 = Console.ReadLine();
                int width;
    
                if (!int.TryParse(input2, out width))
                {
                    Console.WriteLine("Invalid number. Please make it an integer... e.g 1-9");
                }
                else
                {
                    var orientation = (height > width ? Orientation.Landscape : Orientation.Portrait);
                    Console.WriteLine("Your Painting is currently in the: " + orientation + " orientation");
                }
            }
            Console.WriteLine("Do another? Enter yes to do another");
    
            string input = Console.ReadLine();
            if(input != "yes")
            {
              break; //exit loop
            }
          } //end of while loop
        }
    
        public enum Orientation
            {
                Landscape,
                Portrait
    
            }
        }
    }
