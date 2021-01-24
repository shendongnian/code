    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    public static class ToolStripExtensions
    {
        public static IEnumerable<ToolStripItem> Descendants(this ToolStrip toolStrip)
        {
            return toolStrip.Items.Flatten();
        }
        public static IEnumerable<ToolStripItem> Descendants(this ToolStripDropDownItem item)
        {
            return item.DropDownItems.Flatten();
        }
        public static IEnumerable<ToolStripItem> DescendantsAndSelf (this ToolStripDropDownItem item)
        {
            return (new[] { item }).Concat(item.DropDownItems.Flatten());
        }
        private static IEnumerable<ToolStripItem> Flatten(this ToolStripItemCollection items)
        {
            foreach (ToolStripItem i in items)
            {
                yield return i;
                if (i is ToolStripDropDownItem)
                    foreach (ToolStripItem s in ((ToolStripDropDownItem)i).DropDownItems.Flatten())
                        yield return s;
            }
        }
    }
