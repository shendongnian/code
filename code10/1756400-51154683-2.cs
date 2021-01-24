    private async void DataSelectedRecord_OnRecordSelected(object sender, EventArgs e)
    {
        RecordLoaded = false;
        await FillDetails();
        RecordLoaded = true;
    }
    private async Task FillDetails()
    {
        var queryResults = await someDbApiCallAsync();
        // do something with it
    }
