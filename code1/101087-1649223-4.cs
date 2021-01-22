    class Node
    {    
       public void PrintPretty(string indent, bool last)
       {
           Console.Write(indent);
           if (last)
           {
               Console.Write("\\-");
               indent += "  ";
           }
           else
           {
               Console.Write("|-");
               indent += "| ";
           }
           Console.WriteLine(Name);
    
           for (int i = 0; i < Children.Count; i++)
               Children[i].PrintPretty(indent, i == Children.Count - 1);
       }
    }
