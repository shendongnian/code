                string[] suggestions = new string[] {"Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",  
            "Mississippi", "Missouri", "Montana"}; 
 
                System.Console.WriteLine("Before Except "); 
 
                suggestions.ToList().ForEach(str => { System.Console.WriteLine(str); }); 
 
                var unqiueSugs = from sug in suggestions 
                                 where !remQueries.Any(q => q.Equals(sug, StringComparison.OrdinalIgnoreCase)) 
                                 select sug; 
