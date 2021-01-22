        public void InitializeMouseHandlersForVisual(Visual visual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual childVisual = (Visual) VisualTreeHelper.GetChild(visual, i);
                ContentPresenter myContentPresenter = childVisual as ContentPresenter;
                if (myContentPresenter != null)
                {
                    // Finding textBlock from the DataTemplate that is set on that ContentPresenter
                    DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                    if (myDataTemplate != null)
                    {
                        TextBox myTextBox = (TextBox)myDataTemplate.FindName("text", myContentPresenter);
                        MessageBox.Show("textbox Found");
                    }
                }
                InitializeMouseHandlersForVisual(childVisual);
            }
        }
