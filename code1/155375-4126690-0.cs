        private void DataGrid1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.HorizontalChange != 0.0f)
            {
                ScrollViewer sv = null;
                Type t = DataGrid1.GetType();
                try
                {
                    sv = t.InvokeMember("InternalScrollHost", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, DataGrid2, null) as ScrollViewer;
                    sv.ScrollToHorizontalOffset(e.HorizontalOffset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
