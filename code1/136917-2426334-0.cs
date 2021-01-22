            var sb = new StringBuilder();
            foreach(var item in this.listview1.SelectedItems)
            {
                var lvi = this.listview1.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                var cell = this.GetVisualChild<ContentPresenter>(lvi);
                var txt = cell.ContentTemplate.FindName("txtCodCli", cell) as TextBlock;
                sb.Append(txt.Text);
                //TODO: grab the other column's templated controls here & append text
            }
            System.Windows.Clipboard.SetData(DataFormats.Text, sb.ToString());
