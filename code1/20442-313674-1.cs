    foreach( OntologyNode on in Nodes )
     {
         if (on.IsTopLevelNode == true)// internal not pertinent to this code snippet
         {
              TreeNode tn = tvOntoBrowser.Nodes.Add(on.Name);
              tn.Tag = on;
              if (on.Children.Count > 0)
              {
                   RecursiveAdd(on, tn);
              }
         }
      }
