        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeMouseHandlersForVisual(datagrid);
        }
        public void InitializeMouseHandlersForVisual(Visual visual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual childVisual = (Visual) VisualTreeHelper.GetChild(visual, i);
                if (childVisual is TextBox)
                    MessageBox.Show("textbox Found");
                // Recursively enumerate children of the child visual object.
                InitializeMouseHandlersForVisual(childVisual);
            }
        }
