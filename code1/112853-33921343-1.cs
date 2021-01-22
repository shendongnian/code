    private void btnBackgroundImage_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog dlg = new OpenFileDialog();
		dlg.Filter = "Image Files (*.bmp;*.png;*.jpg;)|*.bmp;*.png;*.jpg";
		dlg.Multiselect = false;
		dlg.RestoreDirectory = true;
		if (dlg.ShowDialog() == true)
		{
			txtBackImageName.Text = dlg.FileName;
			_layoutRoot.Background = new System.Windows.Media.ImageBrush(GetImageSource(dlg.FileName));
		}
	}
	public ImageSource GetImageSource(string filename)
	{
		string _fileName = filename;
		BitmapImage glowIcon = new BitmapImage();
		glowIcon.BeginInit();
		glowIcon.UriSource = new Uri(_fileName);
		glowIcon.EndInit();
		return glowIcon;
	}
