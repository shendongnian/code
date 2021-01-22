    // using the Find method uses a Predicate generic delegate.
    if (nodeList.Find(FindNode) == null)
    {
      var tmpCNoteID = dr["CaseNoteID"].ToString();
      var filter = "ParentNote='" + tmpCNoteID + "'";
      DataTable DTCopy = cNoteDT.Copy()
      DataRow[] childRows = DTCopy.Select(filter);
      if (childRows.Length > 0)
      {
        // Recursively call this function for all childRows
        TreeNode[] childNodes = RecurseRows(childRows);
        // Add all childnodes to this node
        node.Nodes.AddRange(childNodes);
      }
      // Mark this noteID as dirty (already added)
      nodeList.Add(node);
    }
