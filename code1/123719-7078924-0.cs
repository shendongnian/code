    ---TRIGGER--
    
    CREATE TRIGGER TriggerTest
    ON EMP
    AFTER INSERT, UPDATE, DELETE 
    
    AS
    BEGIN
    
    declare @day varchar(10)
    select @day=datename(dw,getdate())
    
    declare @hour int
    Select @hour=convert(varchar(2),getdate(),114)
    
    if ( @hour < 9 OR @hour > 13 OR @day = 'Saturday' OR @day = 'Sunday')
    BEGIN
    
    if UPDATE(EMPID)
    RAISERROR ('Error!',1,16)
    rollback tran
    
    END
    
    END
    
    
    
    
    
    Insert into EMP values(1003,'A','A')
    
    drop trigger TriggerTest
    --CLASS--
    ----EMPLOYE----
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestNameSpace
    {
        public class Employee:Person
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
                    if (Id == null)
                    {
                        ichk = 0;
                        Console.WriteLine("No ID entered!");
                    }
    
                    Console.Write("Enter the Salary:");
                    Salary = Convert.ToDecimal(Console.ReadLine());
                    if (Salary < 0)
                    {
                        schk = 0;
                        Console.WriteLine("Invalid Salary");
                    }
    
                    Console.Write("Enter Password:");
                    Password = Convert.ToString(Console.ReadLine());
                    if (password == null)
                    {
                        pchk = 0;
                        Console.WriteLine("Empty Password!");
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
    
    
    
    -----PERSON-----
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
    
            protected DateTime dob;
            public DateTime Dob
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
                Dob = Convert.ToDateTime("09 / 12 / 1990");
                age = 0;
            }
            public Person(string n, char g, DateTime d)
            {
                Name = n;
                Gender = g;
                Dob = d;
                age = DateTime.Now.Year - Dob.Year;
            }
    
            int nchk = 1, gchk = 1, dchk = 1;
            public virtual void Accept()
            {
                try
                {
                    Console.Write("Enter the name:");
                    Name = Console.ReadLine();
                    if(Name == null)
                    {
                        nchk = 0;
                        Console.WriteLine("No name entered!");
                    }
    
                    Console.Write("Enter the Date of birth:");
                    Dob = Convert.ToDateTime(Console.ReadLine());
                    if (Dob == null)
                    {
                        dchk = 0;
                        Console.WriteLine("No date entered!");
                    }
                    else
                    {
                        age = DateTime.Now.Year - Dob.Year;
                    }
    
                    Console.Write("Enter Gender:");
                    Gender = Convert.ToChar(Console.ReadLine());
                    if (Gender != 'm' && Gender != 'M' && Gender != 'F' && Gender != 'f')
                    {
                        gchk = 0;
                        Console.WriteLine("Invalid Gender");                   
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
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
