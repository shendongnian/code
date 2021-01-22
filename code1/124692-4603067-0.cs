    private void AppLoaded(object sender, RoutedEventArgs e)
            {
                if(App.Current.HasElevatedPermissions)
                    {
                    string strPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\test.txt";
                    StreamReader sr = new StreamReader(strPath);
                    textBlock1.Text = sr.ReadToEnd();
                    }
            }
