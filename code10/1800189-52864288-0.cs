    var result = available.Where(x => 
         !unavailable.Any(y => y.Start < x.End && y.End > x.Start));
    
    public class DateRange // obj is awkward naming 
    {
       public DateTime Start {get; set;}
       public DateTime End {get; set;}
    }
