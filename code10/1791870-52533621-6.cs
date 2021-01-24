     using System.Linq;
     ...
     bool hasLabel = pbArray[x,y]
       .Controls
       .OfType<Label>()
       .Any();  
