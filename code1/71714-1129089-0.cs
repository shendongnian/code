Although, to finish off where you started, use the DriveInfo.Name to create a new entry in your custom places:
    System.Windows.Forms.OpenFileDialog dls = new System.Windows.Forms.OpenFileDialog();
    dls.CustomPlaces.Clear();
    foreach (DriveInfo Drive in ListDrives)
    {
        if (Drive.DriveType == DriveType.Removable)
        {
            dls.CustomPlaces.Add(Drive.Name);
        }
        dls.ShowDialog();
    }
