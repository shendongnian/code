    private void AddEventsToAllToolStripMenuitems (ToolStripItemCollection items) {
        foreach (ToolStripItem tsi in items) {
            tsi.MouseEnter += new EventHandler(this.control_MouseEnter);
            tsi.MouseLeave += new EventHandler(this.control_MouseLeave);
            if (tsi is ToolStripMenuItem) {
                ToolStripMenuItem mi = tsi as ToolStripMenuItem;
                AddEventsToAllToolStripMenuitems(mi.DropDownItems);
            }
        }
    }
