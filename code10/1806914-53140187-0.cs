    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a time value in the 24-hour time format. (ex. 19:00)");
            var userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput)) {
                Console.WriteLine("No input");
                return;
            }
            if(!userInput.Contains(':')) {
                Console.WriteLine("Input does not have `:` in it. Invalid Time.");
                return;
            }
            var userComponents = userInput.Split(':');
            if(userComponents.Length != 2) { 
                Console.WriteLine("Invalid Time");
                return;
            }
            if(string.IsNullOrEmpty(userComponents[0]) || string.IsNullOrEmpty(userComponents[1]) {
                Console.WriteLine("No hours or minutes given. Invalid Time");
                return;
            }
            try {
                var hour = Convert.ToInt32(userComponents[0]);
                var minute = Convert.ToInt32(userComponents[1]);    
            } catch(OverFlowException e) {
                // Do something with this.
                return;
            } catch (FormatException e) {
                // Do something with this.
                return;
            }
                   
            if (hour <= 23 && hour >= 00 && minute >= 0 && minute <= 59)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Invalid Time");
         
       }
    }
