    using System;
    using System.Linq;
    public class Simple {
      public static void Main() {
    			var userRoles = (new[] 
    			{ 
    			new { clientid=1 , rowVersion = 1 , role="READ" },
    			new { clientid=1 , rowVersion = 2 , role="EDIT" },
    			new { clientid=2 , rowVersion = 3 , role="ADMIN" },
    			new { clientid=1 , rowVersion = 4 , role="VIEW" }
    		});
    
    var o = userRoles.OrderByDescending(x => x.rowVersion)
    				.GroupBy(x => x.clientid)
                    .SelectMany(g =>
                       g.Select((j, i) => new { j.rowVersion, j.role, rn = i + 1 })
                   	   );
    	  
    	var z =  o.Select(x => new {x.rowVersion, x.role, x.rn}).Where(a => a.rn==1);
    	  
    	  var results = userRoles.GroupBy(x => x.clientid)
                      .Select(x => x.OrderByDescending(y => y.rowVersion).First());
    	  
    	  	  Console.WriteLine("Solution #1");
    
    		foreach (var i in z)
    		{
    			Console.WriteLine("{0} {1} {2}", i.rowVersion, i.role, i.rn);
    		}
    	  
    	  Console.WriteLine("Solution #2");
    
    	  foreach (var k in results)
    		{
    			Console.WriteLine("{0} {1}", k.rowVersion, k.role);
    		}
    	  
      }
      }
