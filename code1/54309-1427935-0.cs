    public partial class ListViewExtended : ListView
    {
       private Collection<Dictionary<string, ListViewGroup>> groupTables = new Collection<Dictionary<string,ListViewGroup>>();
    
       public ListViewExtended()
       {
          InitializeComponent();
       }
    
       /// <summary>
       /// Create groups for each column of the list view.
       /// </summary>
       public void CreateGroups()
       {
          CreateGroups(false);
       }
    
       /// <summary>
       /// Create groups for each column of the list view.
       /// </summary>
       public void CreateGroups(bool reset)
       {
          if (OSFeature.Feature.IsPresent(OSFeature.Themes))
          {
             if (reset)
             {
                this.groupTables.Clear();
             }
    
             for (int column = 0; column < this.Columns.Count; column++)
             {
                Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();
    
                foreach (ListViewItem item in this.Items)
                {
                   string subItemText = item.SubItems[column].Text;
    
                   // Use the initial letter instead if it is the first column.
                   if (column == 0)
                   {
                      subItemText = subItemText.Substring(0, 1).ToUpperInvariant();
                   }
    
                   if (!groups.ContainsKey(subItemText))
                   {
                      groups.Add(subItemText, new ListViewGroup(subItemText) { Name = subItemText });
                   }
                }
    
                this.groupTables.Add(groups);
             }
          }
       }
    
       /// <summary>
       /// Sets the list view to the groups created for the specified column.
       /// </summary>
       /// <param name="column"></param>
       public void SetGroups(int column)
       {
          if (OSFeature.Feature.IsPresent(OSFeature.Themes))
          {
             try
             {
                this.BeginUpdate();
                this.Groups.Clear();
    
                if (column == -1)
                {
                   this.ShowGroups = false;
                }
                else
                {
                   this.ShowGroups = true;
                   Dictionary<string, ListViewGroup> groups = groupTables[column];
                   this.Groups.AddRange(groups.Values.OrderBy(g => g.Name).ToArray());
    
                   foreach (ListViewItem item in this.Items)
                   {
                      string subItemText = item.SubItems[column].Text;
    
                      // For the Title column, use only the first letter.
                      if (column == 0)
                      {
                         subItemText = subItemText.Substring(0, 1).ToUpperInvariant();
                      }
    
                      item.Group = groups[subItemText];
                   }
    
                   groups.Values.ForEach<ListViewGroup>(g => g.Header = String.Format(CultureInfo.CurrentUICulture, "{0} ({1})", g.Name, g.Items.Count));
                }
             }
             finally
             {
                this.EndUpdate();
             }
          }
       }
    }
