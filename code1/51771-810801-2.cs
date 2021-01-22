    public partial class TreeViewColor : Form
    {
      private DataTable dt;
      // Alternate way of maintaining a list of nodes that have already been added.
      //private List<int> doneNotes;
      private static int noteID;
    
      public TreeViewColor()
      {
        InitializeComponent();
      }
    
      private void TreeViewColor_Load(object sender, EventArgs e)
      {
        CreateData();
        CreateNodes();
    
        foreach (TreeNode rootNode in treeView1.Nodes)
        {
          ColorNodes(rootNode, Color.MediumVioletRed, Color.DodgerBlue);
        }
      }
    
      private void CreateData()
      {
        dt = new DataTable("CaseNotes");
        dt.Columns.Add("NoteID", typeof(string));
        dt.Columns.Add("NoteName", typeof(string));
        DataColumn dc = new DataColumn("ParentNoteID", typeof(string));
        dc.AllowDBNull = true;
        dt.Columns.Add(dc);
    
        // Add sample data.
        dt.Rows.Add(new string[] { "1", "One", null });
        dt.Rows.Add(new string[] { "2", "Two", "1" });
        dt.Rows.Add(new string[] { "3", "Three", "2" });
        dt.Rows.Add(new string[] { "4", "Four", null });
        dt.Rows.Add(new string[] { "5", "Five", "4" });
        dt.Rows.Add(new string[] { "6", "Six", null });
        dt.Rows.Add(new string[] { "7", "Seven", null });
        dt.Rows.Add(new string[] { "8", "Eight", "7" });
        dt.Rows.Add(new string[] { "9", "Nine", "8" });
      }
    
      private void CreateNodes()
      {
        DataRow[] rows = new DataRow[dt.Rows.Count];
        dt.Rows.CopyTo(rows, 0);
        //doneNotes = new List<int>(9);
    
        // Get the TreeView ready for node creation.
        // This isn't really needed since we're using AddRange (but it's good practice).
        treeView1.BeginUpdate();
        treeView1.Nodes.Clear();
    
        TreeNode[] nodes = RecurseRows(rows);
        treeView1.Nodes.AddRange(nodes);
    
        // Notify the TreeView to resume painting.
        treeView1.EndUpdate();
      }
    
      private TreeNode[] RecurseRows(DataRow[] rows)
      {
        List<TreeNode> nodeList = new List<TreeNode>();
        TreeNode node = null;
    
        foreach (DataRow dr in rows)
        {
          node = new TreeNode(dr["NoteName"].ToString());
          noteID = Convert.ToInt32(dr["NoteID"]);
    
          node.Name = noteID.ToString();
          node.ToolTipText = noteID.ToString();
    
          // This method searches the "dirty node list" for already completed nodes.
          //if (!doneNotes.Contains(doneNoteID))
    
          // This alternate method using the Find method uses a Predicate generic delegate.
          if (nodeList.Find(FindNode) == null)
          {
            DataRow[] childRows = dt.Select("ParentNoteID = " + dr["NoteID"]);
            if (childRows.Length > 0)
            {
              // Recursively call this function for all childRowsl
              TreeNode[] childNodes = RecurseRows(childRows);
    
              // Add all childnodes to this node.
              node.Nodes.AddRange(childNodes);
            }
    
            // Mark this noteID as dirty (already added).
            //doneNotes.Add(noteID);
            nodeList.Add(node);
          }
        }
    
        // Convert this List<TreeNode> to an array so it can be added to the parent node/TreeView.
        TreeNode[] nodeArr = nodeList.ToArray();
        return nodeArr;
      }
    
      private static bool FindNode(TreeNode n)
      {
        if (n.Nodes.Count == 0)
          return n.Name == noteID.ToString();
        else
        {
          while (n.Nodes.Count > 0)
          {
            foreach (TreeNode tn in n.Nodes)
            {
              if (tn.Name == noteID.ToString())
                return true;
              else
                n = tn;
            }
          }
          return false;
        }
      }
    
      protected void ColorNodes(TreeNode root, Color firstColor, Color secondColor)
      {
        root.ForeColor = root.Index % 2 == 0 ? firstColor : secondColor;
    
        foreach (TreeNode childNode in root.Nodes)
        {
          Color nextColor = childNode.ForeColor = childNode.Index % 2 == 0 ? firstColor : secondColor;
    
          if (childNode.Nodes.Count > 0)
          {
            // alternate colors for the next node
            if (nextColor == firstColor)
              ColorNodes(childNode, secondColor, firstColor);
            else
              ColorNodes(childNode, firstColor, secondColor);
          }
        }
      }
    }
---
