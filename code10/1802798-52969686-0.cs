    class Program
    {
        static List<string> num =  new List<string> (){ "01", "02", "03" }; 
        static string en;
        static string en1;
        static void Main()
        {
            while (true) {
            
                Console.Write("Enter your code: ");
                if (String.IsNullOrEmpty(en)) { //check en isn't set yet
                    en = Console.ReadLine(); // set en 
                    if (num.Contains(en)){ // if en exists in the num list proceed
                        Console.WriteLine("IN");
                    } else {
                        en = null; //if it doesn't null it and start again
                    }
                } else {
                    en1 = Console.ReadLine(); //read in the value to compare
                    if (en == en1) { //compare the original input to this
                        en = null; //if they're the same, null the original 
                        Console.WriteLine("OUT"); 
                    }
                }
                
            }
        }
    }
