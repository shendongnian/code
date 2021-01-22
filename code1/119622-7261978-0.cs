        static ConditionalWeakTable<TabItem, TIDExec> tidByTab = new ConditionalWeakTable<TabItem, TIDExec>();
        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ...
            dataGrid.SelectionChanged += (_sender, _e) =>
            {
                var cs = dataGrid.SelectedItem as ClientSession;
                this.tabControl.Items.Clear();
                foreach (var tid in cs.GetThreadIDs())
                {
                    tid.tabItem = new TabItem() { Header = ... };
                    tid.tabItem.AddHandler(UIElement.MouseDownEvent,
                        new MouseButtonEventHandler((__sender, __e) =>
                        {
                            tabControl_SelectionChanged(tid.tabItem);
                        }), true);
                    tidByTab.Add(tid.tabItem, tid);
                    this.tabControl.Items.Add(tid.tabItem);
                }
            };
        }
        void tabControl_SelectionChanged(TabItem tabItem)
        {
            this.tabControl.SelectedItem = tabItem;
            if (tidByTab.TryGetValue(tabControl.SelectedItem as TabItem, out tidExec))
            {
                tidExec.EnsureBlocksLoaded();
                ShowStmt(tidExec.CurrentStmt);
            }
            else
                throw new Exception("huh?");
        }
