    private void CreateColumns(XmlDocument doc)
    {
        foreach (...) // loop through each node in xml document
        {
             if (node.Name == "Outcome")
             {
                  var items = new List<string>() { "Resolved", "Unresolved", "Pending" };
                  this.dataGridView1.Columns.Add(CreateComboBoxColumn(node.Name, items));
             }
             else
             {
                  this.dataGridView1.Columns.Add(String.Format("col{0}", c), c);
             }
        }
    }
