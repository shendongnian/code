     Document doc = GetActiveDocument();
     if ( doc != null )
     {
         dynamic properties = doc.CustomDocumentProperties;
         foreach (dynamic p in properties)
         {
             Console.WriteLine( p.Name + " " + p.Value);
         }
     }
