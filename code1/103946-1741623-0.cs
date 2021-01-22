    class Driver
    {
        // Purpose: directs the program in what to do and loops the program while np.again != n
        public static void Main()
        {
            //No need to split this into two strings just to concatenate them together immediately
            string pathName = "empdata.txt";
            do
            {
                //Use a list instead of an array to allow for a variable amount of employees
                List<Employee> employees = new List<Employee>();
                TextReader tr = new StreamReader(pathName);
                //This while statement is a common pattern for reading data from a stream.
                //Reademployee was changed to return null when no more employees are present.
                Employee employee;
                while ((employee = Employee.Read(tr)) != null)
                {
                    employees.Add(employee);
                }
            } while (again() != 'n');
        }
        // Make the method static if it doesn't have any relation to any specific object
        // Purpose: asks the user if they want to run the program again
        // Returns: a char ( y or n )
        public static char again()
        {
            char response = ' ';
            while (response != 'y' && response != 'n')
            {
                Console.Write("\nWould you like run again? (y or n)");
                response = char.Parse(Console.ReadLine());
                response = char.ToLower(response);
                Console.Clear();
            }
            return response;
        }
    }
    class Employee
    {
        //This is a nice syntax if using c# 3.5. It allows for simple properties with minimal code.
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public double HourlyWage { get; set; }
        public int HoursWorked { get; set; }
        public Employee()
        {
            //Avoid code duplication by calling the reset method
            Reset();
        }
        public void Reset()
        {
            EmployeeNumber = 0;
            FirstName = "";
            LastName = "";
            Adress = "";
            HourlyWage = 0;
            HoursWorked = 0;
        }
        //This method fits better directly inside the employee class
        public static Employee Read(TextReader tr)
        {
            Employee employee = new Employee();
            string line = tr.ReadLine();
            //We exit as soon as we detect that the file has ended.
            //This makes the code cleaner than having nested if-else.
            //(I personally don't use the {} on single lines, but many do.
            if (line == null) {return null;} //No more posts
            //The whole do-while loop was removed. Unnescessary while loops should always
            //be avoided as they are one of the most difficult code constructs to follow,
            employee.EmployeeNumber = int.Parse(line);
            //Your helpmethod just complicated things. It also contained an unnesscesary loop
            string[] splitName = tr.ReadLine().Split(' ');
            employee.FirstName = splitName[0];
            employee.LastName = splitName[1];
            employee.Adress = tr.ReadLine();
            //Same as above. Also, changed HoursWorked to integer.
            string[] splitHours = tr.ReadLine().Split(' ');
            //InvariantCulture should always be used when dealing with data of a well defined format.
            //Otherwise the code won't work on computers with different culture settings.
            //(Like ones that use "," instead of ".")
            employee.HourlyWage = double.Parse(splitHours[0], System.Globalization.CultureInfo.InvariantCulture);
            employee.HoursWorked = int.Parse(splitHours[1]);
            return employee;
        }
    
        public void Print()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(this.ToString());
            Console.WriteLine("-------------------------------------");
        }
        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Employee Number: --- {0}", EmployeeNumber);
            sb.AppendFormat("           Name: --- {0}, {1}", LastName, FirstName);
            sb.AppendFormat("         Adress: --- {0}", Adress);
            sb.AppendFormat("    Hourly wage: --- {0:f2} (USD per hour)", HourlyWage);
            if (HoursWorked == 1)
                sb.AppendFormat("   Hours Worked: --- 1hr ");
            else
                sb.AppendFormat("   Hours Worked: --- {0:f2}hrs", HoursWorked);
            return sb.ToString();
        }
    }
