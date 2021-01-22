    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1 {
    
      class Foo<T> : List<T> {
      }
    
      class Program {
        static void Main(string[] args) {
    
        var a = new Foo<int>();
        a.Add(1);
        var b = new Foo<string>();
        b.Add("foo");
        Console.WriteLine(BuildClause(a, "foo", true));
        Console.WriteLine(BuildClause(b, "foo", true));
    
        }
    
        private static string BuildClause<T>(IList<T> inClause, string strPrefix, bool addSingleQuotes) {
          StringBuilder sb = new StringBuilder();
    
          //Check to make sure inclause has objects
          if (inClause.Count == 0) 
            throw new Exception("Item count for In() Clause must be greater than 0.");
          sb.Append(strPrefix).Append(" IN(");
          foreach (var Clause in inClause) {
            if (addSingleQuotes) 
              sb.AppendFormat("'{0}'", Clause.ToString().Replace("'", "''"));
            else
              sb.Append(Clause.ToString());
            sb.Append(',');
          }
          sb.Length--;
          sb.Append(") ");
          return sb.ToString();
        }
    
      }
    
    }
