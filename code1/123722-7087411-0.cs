    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestNameSpace
    {
        public class Employee : Person
        {
            string id;
            public string Id
            {
                get { return id; }
                set { id = value; }
            }
    
            decimal salary;
            public decimal Salary
            {
                get { return salary; }
                set { salary = value; }
            }
    
            string password;
            public string Password
            {
                set { password = value; }
            }
    
            int ichk = 1, schk = 1, pchk = 1;
    
    
            public Employee()
                : base()
            {
                Id = null;
                Salary = Convert.ToDecimal("0.0");
                Password = null;
            }
    
            public Employee(string n, char g, DateTime d, string empid, decimal sal, string pwd)
                : base(n, g, d)
            {
                Id = empid;
                Salary = sal;
                Password = pwd;
            }
    
            public override void Accept()
            {
                base.Accept();
                try
                {
                    Console.Write("Enter the EMPID:");
                    Id = Console.ReadLine();
                    if (string.IsNullOrEmpty(Id) == true)
                    {
                        ichk = 0;
                        Console.WriteLine("No ID entered!");
                    }
    
                    string salcheck;
                    Console.Write("Enter the Salary:");
                    salcheck = Console.ReadLine();
                    if (string.IsNullOrEmpty(salcheck) == true)
                    {
                        schk = 0;
                        Console.WriteLine("Invalid Salary");
                    }
                    else
                    {
                        Salary = Convert.ToDecimal(salcheck);
                        if (Salary < 0)
                        {
                            schk = 0;
                            Console.WriteLine("Invalid Salary");
                        }
                    }
    
                    Console.Write("Enter Password:");
                    Password = Console.ReadLine();
                    if (string.IsNullOrEmpty(password) == true)
                    {
                        pchk = 0;
                        Console.WriteLine("Empty Password!");
                    }
                    else
                    {
                        string pwd;
                        int pchk = 0;
                        do
                        {
                            Console.Write("Re-Enter Password:");
                            pwd = Console.ReadLine();
                            if (string.IsNullOrEmpty(pwd) == true || pwd != password)
                                Console.WriteLine("Passwords don't match!");
                            else
                                pchk = 1;
                        } while (pchk == 0);
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
    
            }
    
    
            public override void Print()
            {
                base.Print();
    
                if (ichk == 1)
                {
                    Console.WriteLine("EMPID:{0}", Id);
                }
                else
                    Console.WriteLine("No Id!");
    
                if (schk == 1)
                {
                    Console.WriteLine("Salary:{0}", Salary);
                }
                else
                    Console.WriteLine("Invalid Salary!");
    
            }
    
        }
    }
    
    ------------------------------------------------------------------
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestNameSpace
    {
        public class Person
        {
            protected string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
    
            protected char gender;
            public char Gender
            {
                get { return gender; }
                set { gender = value; }
            }
    
            protected DateTime? dob;
            public DateTime? Dob
            {
                get { return dob; }
                set { dob = value; }
            }
    
            protected int age;
            public int Age
            {
                get { return age; }
            }
    
            public Person()
            {
                Name = "Default";
                Gender = 'M';
                Dob = null;
                age = 0;
            }
            public Person(string n, char g, DateTime d)
            {
                Name = n;
                Gender = g;
                Dob = d;
                age = DateTime.Now.Year - Dob.Value.Year;
            }
    
            int nchk = 1, gchk = 0, dchk = 0;
            string datetimecheck, gendercheck;
            public virtual void Accept()
            {
                try
                {
                    Console.Write("Enter the name:");
                    Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(Name)==true)
                    {
                        nchk = 0;
                        Console.WriteLine("No name entered!");
                    }
    
                    Console.Write("Enter the Date of birth:");
                    datetimecheck = Console.ReadLine();
                    if (string.IsNullOrEmpty(datetimecheck) == true)
                    {                    
                        dchk = 0;
                        Console.WriteLine("No date entered!");
                    }
                    else
                    {
                        Dob = Convert.ToDateTime(datetimecheck);
                        age = DateTime.Now.Year - Dob.Value.Year;
                        dchk = 1;
                    }
    
                    Console.Write("Enter Gender:");
                    gendercheck = Console.ReadLine();
                    if (gendercheck != "m" && gendercheck != "M" && gendercheck != "f" && gendercheck != "F")
                    {
                        gchk = 0;
                        Console.WriteLine("Invalid Gender");
                    }
                    else
                    {
                        gchk = 1;
                        Gender = Convert.ToChar(gendercheck);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
    
            }
    
            public virtual void Print()
            {
                Console.WriteLine("\n\nThe Employee Details are:\n");
    
                if (nchk == 1)
                {
                    Console.WriteLine("Name:{0}", Name);
                }
                else
                    Console.WriteLine("No Name!");
    
                if (gchk == 1)
                {
                    Console.WriteLine("Gender:{0}", Gender);
                }
                else
                    Console.WriteLine("No Gender!");
    
                if (dchk == 1)
                {
                    Console.WriteLine("Date Of Birth:{0}", Dob);
                    Console.WriteLine("Age:{0}", Age);
                }
                else
                    Console.WriteLine("No Date Of Birth!");
            }
        }
    }
