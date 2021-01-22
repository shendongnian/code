        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ((DataGrid)sender).CaptureMouse();
        }
        private void DataGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ((DataGrid)sender).ReleaseMouseCapture();
        }
