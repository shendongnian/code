    private void AddNewCentre(Centre centre)
    {
        meetingData.MeetingCentres.Add(centre);
    }
    private void BtnNew_Click(object sender, RoutedEventArgs e)
    {
        New newWindow = new New(AddNewCentre);
        newWindow.Show();
    }
