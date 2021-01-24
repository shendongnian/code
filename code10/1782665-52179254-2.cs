    using System.Collections.Generic;
    using System.Windows.Forms;
    public static class ToolStripExtensions
    {
        public static IEnumerable<ToolStripItem> AllItems(this ToolStrip toolStrip)
        {
            return toolStrip.Items.Flatten();
        }
        public static IEnumerable<ToolStripItem> Flatten(this ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripDropDownItem)
                    foreach (ToolStripItem subitem in 
                        ((ToolStripDropDownItem)item).DropDownItems.Flatten())
                            yield return subitem;
                yield return item;
            }
        }
    }
