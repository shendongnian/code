    class MainWindow
	{
		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
            SomeRepository repo = new SomeRepository();
            var userName = repo.GetUserName(1);
            MessageBox.Show(userName ?? "User not found!");
        }
	}
