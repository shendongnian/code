    using System;
    using System.Data;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        { 
            string a = "2ch";
            string b = "\uff12\uff43\uff48";
            
            DataTable table = new DataTable();            
            CompareInfo ci = table.Locale.CompareInfo;
            
            // Prints 0, i.e. equal
            Console.WriteLine(ci.Compare(a, b, CompareOptions.IgnoreWidth));
        }
    }
