    private void BtnToDatabase_Click(object sender, RoutedEventArgs e)
    {
        bool dupe = false;
        foreach (File file in lbfiles.Items.OfType<File>())
        {
            string name = file.Name;
            string path = file.Path;
                    ...
        }
    }
