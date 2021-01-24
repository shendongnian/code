    private static void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
	{
		string driveLetter = (string)listBox.SelectedItem;
		int index = drives.FindIndex(x => x.Name == driveLetter);
		
        //Perform the work of changing the driveletter using index or driveletter
		drives = DriveInfo.GetDrives().ToList();
		listBox.ItemsSource = drives;
	}
