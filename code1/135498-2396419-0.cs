        private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow parent = new MainWindow();
            if (parent is IStateChanger)
                ((IStateChanger)parent).GoToElementState("LoggedOn");
        }
