    public class MyClass
    {
       MyNumber MyDecimal {get;set;}
    }
    
    struct MyNumber
    {
        decimal Value {get;set;}
    
        ToString()
        {
            // Adapt number Format and CultureInfo as wanted
            return value.ToString("0:0.##", MyCultureInfo);
        }
    }
