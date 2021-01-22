        // Using Microsoft.VisualBasic;
        
        var txt = "ABCDEFG";
        
        if (Information.IsNumeric(txt))
            Console.WriteLine ("Numeric");
    
    IsNumeric("12.3"); // true
    IsNumeric("1"); // true
    IsNumeric("abc"); // false
 
