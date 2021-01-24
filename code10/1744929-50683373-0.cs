    using System;
    using System.Reflection;
    using System.Windows.Forms;
    public static class ListViewItemExtensions
    {
        public static void Activate(this ListViewItem item)
        {
            if (item.ListView == null)
                throw new InvalidOperationException();
            var onItemActivate = item.ListView.GetType().GetMethod("OnItemActivate",
                BindingFlags.NonPublic | BindingFlags.Instance);
            item.Selected = true;
            onItemActivate.Invoke(item.ListView, new object[] { EventArgs.Empty });
        }
    }
