            string name = String.Empty;
            string department = String.Empty;
            int age = 0;
            Console.WriteLine("Please, enter the name of your employee, then press ENTER");
            name = Console.ReadLine();
            Console.WriteLine("Please, enter the department of your employee, then press ENTER");
            department = Console.ReadLine();
            Console.WriteLine("Please, enter the age of your employee, then press ENTER");
            Int32.TryParse(Console.ReadLine(), out age); // default 0
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Department: " + department);
            Console.WriteLine("Age: " + age.ToString());
