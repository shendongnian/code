    private void DataGridRow_MouseDoubleClick( object sender, MouseButtonEventArgs e )
    {
        this.Dispatcher.BeginInvoke(
            ( Action )delegate
            {
                TestWindow window = new TestWindow();
                window.Show();
                window.Activate();
            },
            System.Windows.Threading.DispatcherPriority.Background,
            null
            );
    }
