    ReferenceDescriptionCollection refdescs;
          
          byte[] continuationPoint;
    
    
          session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out continuationPoint, out refdescs);
    
    
          foreach (var item in refdescs)
          {
            if (item.DisplayName.Text == "_System")
            {
              var nsi = item.NodeId.NamespaceIndex.ToString();
              Console.WriteLine($"Namespace Index {nsi}");
            }
          }
