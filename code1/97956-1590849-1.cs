    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var emails = new Dictionary<int, string>();
    
                emails.Add(1, "Marry@yahoo.com");
                emails.Add(2, "Helan@gmail.com");
                emails.Add(3, "Rose");
                emails.Add(4, "Ana");
                emails.Add(5, "Dhia@yahoo.com");
    
                var validemails = emails.Where(p => IsValidFormat(p.Value)).ToList();
            }
    
    
            public static bool IsValidFormat(string inputEmailId)
            {
                const string format = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}.\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    
                var rex = new Regex(format);
                return rex.IsMatch(inputEmailId);
            }
        }
    }
