    using System;
    
    public class Example
    {
       public static void Main()
       {    
        string d1 = "Jan 1, 2009";
        string d2 = "Feb 2, 2008";
        DateTime date1 = DateTime.Parse(d1);
        DateTime date2 = DateTime.Parse(d2);
        int result = DateTime.Compare(date1, date2);
        string relationship;
    
        if (result < 0)
         relationship = "is earlier than";
        else if (result == 0)
         relationship = "is the same time as";
        else
         relationship = "is later than";
    
        Console.WriteLine("{0} {1} {2}", date1, relationship, date2);
       }
    } 
