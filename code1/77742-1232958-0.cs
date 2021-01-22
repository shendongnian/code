    foreach (DriveInfo Drive in ListAllDrives)
    {
        //Create ListViewItem, give name etc.
        ListViewItem NewItem = new ListViewItem();
        NewItem.Text = Drive.Name;
        //Check type and get icon required.
        if (Drive.DriveType.Removable)
        {
        //Set Icon as Removable Icon
        }    
        //else if (Drive Type is other... etc. etc.)
    }
