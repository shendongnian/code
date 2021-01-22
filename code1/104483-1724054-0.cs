       public class Test
       {
          public bool Bool { get; set; }
       }
    
       class Program
       {
    
          static void Main(string[] args)
          {
             // fill test list
             var list = new List<Test>();
             for (int i=0; i<1e7; i++)
             {
                list.Add(new Test() { Bool = (i % 2 == 0) });
             }
             // warm-up
             int counter = 0;
             DateTime start = DateTime.Now;
             for (int i = 0; i < list.Count; i++)
             {
                if (list[i].Bool)
                {
                   counter++;
                }
             }
       
             // List.FindAll
             counter = 0;
             start = DateTime.Now;
             foreach (var test in list.FindAll(x => x.Bool))
             {
                counter++;
             }
             // prints 7969158
             Console.WriteLine(DateTime.Now.Ticks - start.Ticks); 
    
             // IEnumerable.Where
             counter = 0;
              start = DateTime.Now;
             foreach (var test in list.Where(x => x.Bool))
             {
                counter++;
             }
             // prints 5156514
             Console.WriteLine(DateTime.Now.Ticks - start.Ticks);
    
             // for loop
             counter = 0;
             start = DateTime.Now;
             for (int i = 0; i < list.Count; i++)
             {
                if (list[i].Bool)
                {
                   counter++;
                }
             }
             // prints 2968902
             Console.WriteLine(DateTime.Now.Ticks - start.Ticks);
    
    
          }
