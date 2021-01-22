     var node = db.Nodes.Where( n => n.Name == "Node2" ).SingleOrDefault();
     string path = string.Empty;
     while (node != null)
     {
         path = string.Format( "/{0}{1}", node.Name, path );
         node = db.Nodes.Where( n => n.ParentId == node.Id ).SingleOrDefault();
     }
