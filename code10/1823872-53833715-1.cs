        public void SortItems()
        {
            this.LeftPanel.Children.RemoveRange(0, this.LeftPanel.Children.Count);
            this.RightPanel.Children.RemoveRange(0, this.RightPanel.Children.Count);
            this.m_items.Where(i => i.Visibility == Visibility.Visible).ToList().ForEach((i) => { (this.LeftPanel.Children.Count == this.RightPanel.Children.Count ? this.LeftPanel : this.RightPanel).Children.Add(i); } );
        }
