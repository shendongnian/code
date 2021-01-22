        private void OrgTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null)
            {
                var parent = ((TreeView)sender).GetParentItem(e.NewValue);
                if (parent != null)
                {
                    Status.Text = "Parent is " + parent.ToString();
                }
            };
        }
