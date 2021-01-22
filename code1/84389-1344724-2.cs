    public class OurClass : IOurTemplate<string,MyClass>
    {
        IEnumerable<string> List()
        {
            yield return "Some String"; // put implementation here
        }
        string Get(MyClass id)
        {
            
            return id.Name; // put implementation here
        }
    }
