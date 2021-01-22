     private bool TabPageShown(TabControl tabCtrl, int tabIndex)
            {
                 Rectangle rct = tabCtrl.GetTabRect(tabIndex);
                 int scrollBarWidth = 24;
                 if (rct.X - scrollBarWidth < tabCtrl.Width)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
            }
