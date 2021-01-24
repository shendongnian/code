    private Point DeterminePosition()
        {
            Point point = this.position;
            if (ParentTreeViewItem != null)
            {
                MyTreeViewItem parent = null, lastCollapsed = null;
                parent = ParentTreeViewItem;
                while (parent != null)
                {
                    if (parent.IsExpanded == false)
                    {
                        lastCollapsed = parent;
                    }
                    parent = parent.ParentTreeViewItem;
                }
                if (lastCollapsed != null)
                {
                    point = new Point(position.X, lastCollapsed.Position.Y);
                }
            }
     
            return point;
        }
