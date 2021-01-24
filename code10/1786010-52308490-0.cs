    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            // Imagine this somewhere entirely different
            var badCulture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            badCulture.NumberFormat.NegativeSign = "0 OR 1=1 OR Id=";        
            CultureInfo.CurrentCulture = badCulture;
            
            // Here's the code that looks innocent
            var idPair = new KeyValuePair<int, int>(-5, 10);
            string table = "Foo";
            string commandText = $"UPDATE {table} SET Id={idPair.Value} WHERE Id={idPair.Key};";
            
            Console.WriteLine(commandText);
        }
    }
