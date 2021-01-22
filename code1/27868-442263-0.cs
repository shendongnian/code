    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            var template = "On $today$ you need to do something.";
            var regex = new Regex(@"\$today\$");
            var text = regex.Replace(template,
                match => DateTime.Now.ToString("d"));
            Console.WriteLine(text);
        }
    }
