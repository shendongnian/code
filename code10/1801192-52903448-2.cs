    class Program
    {
        public static List<List<string>> mData { get; private set; } //Use mData in any method.
        static void Main(string[] args)
        {
            Header();       // Call Header Method & display
            Menu();         // Call Menu Method & display
            CCDatabase();   // Call Calendar Counter Database Method, execute & display.
            //Console.WriteLine("Hello World!");
            ExitProgram(); //Call exit program, execute & display
        }
        static void Header()
        {
            Console.Clear(); //Clear console buffer & console window of display information
            Console.Write("--------------------\n| Calendar Counter |\n--------------------\n"); //Display Header text
        }
        static void Menu()
        {
            //ADD menu options once basic program is working!!
            Console.WriteLine(); //Space
            Console.Write("MENU: //ADD menu options once basic program is working!!");
            Console.WriteLine("\n"); //Double Space
        }
        static void CCDatabase()
        {
            mData = MonthDataBase();
            Console.Write("Enter a month?: ");
            string userMonth = (Console.ReadLine());
            if (mData.Any(x => x.Contains(userMonth))) //Compare user input to MonthDataBase
            {
                var month = mData.Where(x => x.Contains(userMonth)).Select(x => new { Days = x[0], Name = x[1] }).FirstOrDefault();
                Console.WriteLine($"{month.Name} has {month.Days} days in it.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You didn't type a word in the database.");
            }
        }
        public static List<List<string>> MonthDataBase() //Month Database
        {
            var mData = new List<List<string>>  {
          new List<string>  { "31", "January", "january", "Jan", "jan", "Jan.", "jan.", "1", "01" }, //If user types 1-8 display corresponding message in CCDatatbase()
          new List<string>  { "28/29", "February", "february", "Feb", "feb", "Feb.", "feb.", "2", "02" },
          new List<string>  { "31", "March", "march", "Mar", "mar", "Mar.", "mar.", "3", "03" },
          new List<string>  { "30", "April", "april", "Apr", "apr", "Apr.", "apr.", "4", "04" },
          new List<string>  { "31", "May", "may", "May", "may", "May", "may", "5", "05" },
          new List<string>  { "30", "June", "june", "Jun", "jun", "Jun.", "jun.", "6", "06" },
          new List<string>  { "31", "July", "july", "Jul", "jul", "Jul.", "jul.", "7", "07" },
          new List<string>  { "31", "August", "august", "Aug", "aug", "Aug.", "aug.", "8", "08" },
          new List<string>  { "30", "September", "september", "Sep", "sep", "Sep.", "sep.", "9", "09" },
          new List<string>  { "31", "October", "october", "Oct", "oct", "Oct.", "oct.", "10", "10" },
          new List<string>  { "30", "November", "november", "Nov", "nov", "Nov.", "nov.", "11", "11" },
          new List<string>  { "31", "December", "december", "Dec", "dec", "Dec.", "dec.", "12", "12" }
        };
            return mData;
        }
        static void ExitProgram()
        {
            //REPLACE later with an actual exit option in menu!!
            Console.Write("EXIT: //REPLACE later with an actual exit option in menu!!\n\n");
            //Prevent Debugging test from closing.
            Console.Write("Press any key to Exit...");
            Console.ReadLine();
        }
    }
