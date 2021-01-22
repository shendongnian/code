    PreviewMouseWheel and mark the event as handled:
        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                scrollViewer1.LineDown();
            }
            else
            {
                scrollViewer1.LineUp();
            }
        }
