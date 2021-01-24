    using System;
    using System.Collections.Generic;
    using System.Linq; 
    
    public class ExampleObject
    {
      public int Id { get; set; }
      public IEnumerable<int> Types { get; set; }
    }
    
    class Program
    {
      static void Main (string [] args)
      {
        var obs = new List<ExampleObject>
        {
          new ExampleObject
          {
            Id=1,
            Types=new List<int> { 94, 13, 11, 67, 254, 256, 226, 82, 1, 66, 497, 21 } 
          },
          new ExampleObject
          {
            Id=288,
            Types=new List<int> { 94, 13, 11, 67,      256, 226, 82, 1, 66, 497, 21 } 
          },
        };
    
        var must_support = new List<int>{11, 67, 254, 256, 226, 82, };  // only Id 1 fits
        var must_support2 = new List<int>{11, 67, 256, 226, 82, };      // both fit
    
</pre>    // this is the actual check: see for all objects in obs 
    // if all values of must_support are in the Types - Listing
    var supports  = obs.Where(o => must_support.All(i => o.Types.Contains(i)));
    var supports2 = obs.Where(o => must_support2.All(i => o.Types.Contains(i)));</code></pre>
    
        Console.WriteLine ("new List<int>{11, 67, 254, 256, 226, 82, };");
        foreach (var o in supports)
          Console.WriteLine (o.Id);
    
        Console.WriteLine ("new List<int>{11, 67, 256, 226, 82, };");
        foreach (var o in supports2)
          Console.WriteLine (o.Id);
    
        Console.ReadLine ();
      }
    }
    
