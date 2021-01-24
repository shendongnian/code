    public class myObject{
     public int counter;
    }    
    
    [HttpPost]
    public void Post([FromBody] myObject value)
    {
       Console.WriteLine("Value --> " + value.counter.toString() );
    }
 
 
