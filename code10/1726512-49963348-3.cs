    using System;
    
    class Test
    {
        private DateTime dateOfBirth;
        
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                // Alternative: if (DateTime.Now.AddYears(-16) > value)
                // They behave differently around leap years. Note that
                // currently this is sensitive to the system time zone
                // and the system clock.
                if (value.AddYears(16).Date > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "User must be at least 16 years old");
                }
                dateOfBirth = value;
            }
        }
        
        public Test(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Note: executed on April 22nd 2018
            Test test = new Test(new DateTime(1970, 1, 1));
            Console.WriteLine(test.DateOfBirth);
            test.DateOfBirth = new DateTime(2002, 4, 22); // Fine: 16th birthday
            Console.WriteLine(test.DateOfBirth);
            test.DateOfBirth = new DateTime(2002, 4, 23);
        }
    }
