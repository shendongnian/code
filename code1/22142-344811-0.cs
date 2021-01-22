    using System.Linq.Expressions; //in System.Core.dll
    Expression BuildExpr(XmlNode xmlNode)
     { switch(xmlNode.Name)
        { case "Add":
           { return Expression.Add( BuildExpr(xmlNode.ChildNodes[0])
                                   ,BuildExpr(xmlNode.ChilNodes[1]));
           } 
          /* ... */
            
        }
     }
