    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Items collection.
            // Add your list view items to this.
            // Note the fact that we have a different amount of subitems!!!
            var items = new List<ListViewItem>
            {
                new ListViewItem(new []{"Hello", "Stack","Overflow"}), 
                new ListViewItem(new []{"ObjectListView is pretty damn neat!"}), 
                new ListViewItem(new []{"Pretty", "Cool"})
            };
            // These are set up by the WinForms Designer when I create OLV columns in the designer.
            // Here, I am telling each column to use a custom getter, created by the SubItemGetter method.
            // ensures the sub-items actually exist on each LVI.
            olvColumn1.AspectGetter = SubItemGetter(0); // ListViewItem's first sub-item is the same as ListViewItem.Text. :)
            olvColumn2.AspectGetter = SubItemGetter(1);
            olvColumn3.AspectGetter = SubItemGetter(2);
            // NOTE: I assume you know at design-time how many columns there are in your list view.
            // Set them up as I've done above, or, if you want to be fancy..
            for (int index = 0; index < objectListView1.Columns.Count; index++)
            {
                OLVColumn column = objectListView1.AllColumns[index];
                column.AspectGetter = SubItemGetter(index);
            }
            // Tells OLV to use the items collection.
            objectListView1.SetObjects(items);
            // Sometime later, probably somewhere else in the code...
            items.Add(new ListViewItem(new []{"I","Dont","Care","How","Many","SubItems","There","Is!"}));
            // Tell OLV to rebuild!
            objectListView1.BuildList(shouldPreserveState:true); // I'd like to preserve state, please :)
        }
        private AspectGetterDelegate SubItemGetter(int subItemIndex)
        {
            // This returns a method that gives OLV the string it needs to render each cell,
            // while also making sure the sub item exists.
            return rowObject =>
            {
                // Cast the row object to a ListViewItem. This should be safe.
                var lvi = (ListViewItem) rowObject;
                // Make sure the index is not out of range.
                if (lvi.SubItems.Count <= subItemIndex)
                    return null;
                // Return what needs to be displayed!
                return lvi.SubItems[subItemIndex].Text;
            };
        }
    }
