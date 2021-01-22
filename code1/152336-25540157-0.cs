    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Merger
    {
      class Program
      {
        static void Main(string[] args)
        {
          int[] a = { 1, 3, 6, 102, 105, 230 };
          int[] b = { 101, 103, 112, 155, 231 };
    
          var mm = new MergeMania();
    
          foreach(var val in mm.Merge<int>(a, b))
          {
            Console.WriteLine(val);
          }
          Console.ReadLine();
        }
      }
    
      public class MergeMania
      {
        public IEnumerable<T> Merge<T>(params IEnumerable<T>[] sortedSources) 
          where T : IComparable
        {
          if (sortedSources == null || sortedSources.Length == 0) 
            throw new ArgumentNullException("sortedSources");
          
          //1. fetch enumerators for each sourc
          var enums = (from n in sortedSources 
                 select n.GetEnumerator()).ToArray();
          
          //2. fetch enumerators that have at least one value
          var enumsWithValues = (from n in enums 
                       where n.MoveNext() 
                       select n).ToArray();
          if (enumsWithValues.Length == 0) yield break; //nothing to iterate over
           
          //3. sort by current value in List<IEnumerator<T>>
          var enumsByCurrent = (from n in enumsWithValues 
                      orderby n.Current 
                      select n).ToList();
          //4. loop through
          while (true)
          {
            //yield up the lowest value
            yield return enumsByCurrent[0].Current;
    
            //move the pointer on the enumerator with that lowest value
            if (!enumsByCurrent[0].MoveNext())
            {
              //remove the first item in the list
              enumsByCurrent.RemoveAt(0);
    
              //check for empty
              if (enumsByCurrent.Count == 0) break; //we're done
            }
            enumsByCurrent = enumsByCurrent.OrderBy(x => x.Current).ToList();
          }
        }
      }
    }
