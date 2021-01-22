    private static void Write(IEnumerable<Competition> competitions, int indent)
    {
       foreach (var c in competitions)
       {
           string line = String.Empty;
    
           for (int i = 0; i < indent; i++)
           {
              line += "\t";
           }
    
           line += "CompetitionID = " + c.CompetitionID.ToString();
    
           Console.WriteLine(line);
    
           if (c.Childs != null && c.Childs.Count() > 0)
           {
               int id = indent + 1;
               Write(c.Childs, id);
            }
       }
    }
