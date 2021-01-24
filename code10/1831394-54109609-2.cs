    class Program
    {
        static void Main(string[] args)
        {
    
            int height = AskForInt("What is the Height of the Painting?");
            int width = AskForInt("What is the Width of the Painting?");
    
            var orientation = (height > width ? Orientation.Landscape : Orientation.Portrait);
    
            Console.WriteLine("Your Painting is currently in the: " + orientation + " orientation");
    
        }
    
        static int AskForInt(string question) {
            Console.WriteLine(question);
    
            while (true) //use a loop to keep asking the user if they didn't provide a valid answer
            {
                string input = Console.ReadLine();
                int answer;
    
                if (!int.TryParse(input, out answer))
                {
                    Console.WriteLine("Not a valid integer. Please enter an integer: ");
                }
                else
                {
                    return answer; //exit this method, returning the int
                }
            }
        }
    
        public enum Orientation
        {
            Landscape,
            Portrait
    
        }
    }
