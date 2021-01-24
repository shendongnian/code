        private static bool IsMouseOnDropDown(ToolStripItemCollection itemCollection)
        {
            Point pnt = Cursor.Position;
            //All what we do is check, if some of DropDownMenus from input collection is active (Visible) 
            //and if mouse position is in it
            for (int i = 0; i < itemCollection.Count; i++)
            {
                if ((itemCollection[i] as ToolStripMenuItem).DropDown.Visible
                    && (itemCollection[i] as ToolStripMenuItem).DropDown.Bounds.Contains(pnt))
                {
                    return true;
                }
            }
            return false;
        }
        private static ContextMenuStrip GetPrimaryOwner(ToolStripDropDownMenu dropDownMenu)
        {
            //All what we do is take owner by owner until we find our CMS,
            //which is the last one -> primary owner
            object cmsItems = dropDownMenu;
            while (!(cmsItems is ContextMenuStrip))
            {
                cmsItems = (cmsItems as ToolStripDropDownMenu).OwnerItem.Owner;
            }
            return cmsItems as ContextMenuStrip;
        }
