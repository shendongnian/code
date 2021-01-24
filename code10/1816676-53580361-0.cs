    class members
    {
        public string name_;
        public int age_;
        public double salary_; 
        public int Age
        {
            get { return age_; }
            set { age_ = value; }
            
        }
        public string Name 
        {
            get { return name_; }
            set { name_ = value; }
        }
        public double Salary
        {
            get { return salary_; }
            set { salary_ = value; }
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                menu();
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Signup();
                }
                else if (input == "2")
                {
                    seeValue(newMn);
                }
                else if ( input == "3")
                {
                    Quit();
                }
            }
        }
        public static void menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("sign up: ");
            Console.WriteLine("See members: ");
            Console.WriteLine("Quite: ");
        }
        public static int Signup()
        {
            members newMn = new members();
            Console.Write("Whats your name: ");
           
            newMn.name_ = Console.ReadLine();
            Console.Write("Whats your age: ");
            newMn.age_ = Convert.ToInt32(Console.ReadLine());
            Console.Write("Whats yor salary income: ");
            newMn.salary_ = Convert.ToDouble(Console.ReadLine());
            
            
            return 1;
        }
        public  static void seeValue( members newMn)
        {
            
            Console.WriteLine(newMn);
        }
        static void Quit()
        {
            Environment.Exit(0);
        }
    }
}
