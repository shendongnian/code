        private void addtabbutton_Click(object sender, RoutedEventArgs e)
        {
            // We use tabItem1 and codebox as template<typename T> for the new objects.
            var tabitem = new System.Windows.Controls.TabItem();
            tabitem.ContextMenu = tabItem1.ContextMenu;
            tabitem.ContextMenuClosing += tabItem1_ContextMenuClosing;
            tabitem.ContextMenuOpening += tabItem1_ContextMenuOpening;
            tabitem.Header = "Code" + NewTabItemIndex.ToString();
            tabitem.Height = tabItem1.Height;
            tabitem.Width = tabItem1.Width;
            tabitem.HorizontalAlignment = tabItem1.HorizontalAlignment;
            tabitem.VerticalAlignment = tabItem1.VerticalAlignment;
            tabitem.DataContext = tabItem1.DataContext;
            var textbox = new System.Windows.Controls.TextBox();
            tabitem.Content = textbox;
            textbox.DataContext = codebox.DataContext;
            textbox.LayoutTransform = codebox.LayoutTransform;
            textbox.AcceptsReturn = true;
            textbox.AcceptsTab = true;
            textbox.Height = this.codebox.Height;
            textbox.HorizontalAlignment = codebox.HorizontalAlignment;
            textbox.VerticalAlignment = codebox.VerticalAlignment;
            NewTabItemIndex++;
            this.tabControl1.Items.Add(tabitem);
        }
